using CodeCompilerServiceConfig.Logic;
using CodeCompilerServiceManager.Settings;
using System.ComponentModel;
using System.ServiceProcess;

namespace CodeCompilerServiceManager
{
    public partial class AppForm : Form
    {
        ServiceProxy serviceConnector = new ServiceProxy();

        private System.Windows.Forms.Timer serviceStatusTimer;
        private BackgroundWorker workerOnStart;
        private BackgroundWorker workerOnStop;
        private BackgroundWorker workerOnRestart;

        private bool restartRequired = false;

        public AppForm()
        {
            InitializeComponent();
            LoadOptions();
            labelServiceStatus.Text = "Stan us³ugi: Pobieranie...";
            InitTimer();
            InitWorkers();
            CheckStatus(null, null);
        }

        private void LoadOptions()
        {
            AppSettingsModel model = AppSettings.LoadSettings();
            numericUpDownIntervalRefresh.Value = model.CheckStatusInterval;
            numericOperationTimeout.Value = Convert.ToDecimal(model.OperationTimeout.TotalMilliseconds);
        }

        private void InitTimer()
        {
            serviceStatusTimer = new System.Windows.Forms.Timer();
            serviceStatusTimer.Tick += new EventHandler(CheckStatus);
            serviceStatusTimer.Interval = AppSettings.CheckStatusInterval;
            serviceStatusTimer.Start();
        }

        #region backgroundWorkers
        private void InitWorkers()
        {
            workerOnStart = new BackgroundWorker();
            workerOnStart.DoWork += workerOnStart_DoWork;
            workerOnStart.RunWorkerCompleted += workerOnStart_RunWorkerCompleted;

            workerOnStop = new BackgroundWorker();
            workerOnStop.DoWork += workerOnStop_DoWork;
            workerOnStop.RunWorkerCompleted += workerOnStop_RunWorkerCompleted;

            workerOnRestart = new BackgroundWorker();
            workerOnRestart.DoWork += workerOnRestart_DoWork;
            workerOnRestart.RunWorkerCompleted += workerOnRestart_RunWorkerCompleted;
        }

        private void workerOnRestart_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            OnStatusChanged((ServiceControllerStatus)Convert.ToInt32(e.Result));
        }

        private void workerOnRestart_DoWork(object? sender, DoWorkEventArgs e)
        {
            e.Result = serviceConnector.RestartService();
        }

        private void workerOnStop_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            OnStatusChanged((ServiceControllerStatus)Convert.ToInt32(e.Result));
        }

        private void workerOnStop_DoWork(object? sender, DoWorkEventArgs e)
        {
            e.Result = serviceConnector.StopService();
        }

        private void workerOnStart_DoWork(object? sender, DoWorkEventArgs e)
        {
            e.Result = serviceConnector.RunService();
        }

        private void workerOnStart_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            OnStatusChanged((ServiceControllerStatus)Convert.ToInt32(e.Result));
        }
        #endregion


        #region formEvents
        private void btnStartService_Click(object sender, EventArgs e)
        {
            labelServiceStatus.Text = "Trwa uruchamianie us³ugi...";
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
            btnStartService.Enabled = false;
            btnReStartService.Enabled = false;
            workerOnStart.RunWorkerAsync();
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            labelServiceStatus.Text = "Trwa zatrzymywanie us³ugi...";
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
            btnStopService.Enabled = false;
            btnReStartService.Enabled = false;
            workerOnStop.RunWorkerAsync();
        }

        private void btnReStartService_Click(object sender, EventArgs e)
        {
            labelServiceStatus.Text = "Trwa restartowanie us³ugi...";
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
            btnStopService.Enabled = false;
            btnReStartService.Enabled = false;
            workerOnRestart.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppSettingsModel model = new AppSettingsModel()
            {
                CheckStatusInterval = Convert.ToInt32(numericUpDownIntervalRefresh.Value),
                OperationTimeout = TimeSpan.FromMilliseconds(Convert.ToDouble(numericOperationTimeout.Value))
            };
            AppSettings.SaveSettings(model);
        }

        private void numericUpDownIntervalRefresh_ValueChanged(object sender, EventArgs e)
        {
            AppSettings.CheckStatusInterval = Convert.ToInt32(numericUpDownIntervalRefresh.Value);
            serviceStatusTimer.Interval = AppSettings.CheckStatusInterval;
            SaveManagerSettings();
        }

        private void numericOperationTimeout_ValueChanged(object sender, EventArgs e)
        {
            AppSettings.OperationTimeout = TimeSpan.FromMilliseconds(Convert.ToDouble(numericOperationTimeout.Value));
            SaveManagerSettings();
        }

        #endregion

        private void CheckStatus(object sender, EventArgs e)
        {
            ServiceControllerStatus result = serviceConnector.GetServiceStatus();
            OnStatusChanged(result);
        }

        private void OnStatusChanged(ServiceControllerStatus status)
        {
            btnReStartService.Enabled = true;
            switch (status)
            {
                case ServiceControllerStatus.Stopped:
                    OnStopped();
                    break;
                case ServiceControllerStatus.StartPending:
                    OnStartPending();
                    break;
                case ServiceControllerStatus.StopPending:
                    OnStopPending();
                    break;
                case ServiceControllerStatus.Running:
                    OnRunning();
                    break;
                default:
                    OnOtherStatus(status);
                    break;
            }
        }

        private void OnStopped()
        {
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.red;
            labelServiceStatus.Text = "Stan us³ugi: Zatrzymana";
            btnStartService.Enabled = true;
            btnStopService.Enabled = false;
        }

        private void OnRunning()
        {
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.green;
            labelServiceStatus.Text = "Stan us³ugi: Uruchomiona";
            btnStartService.Enabled = false;
            btnStopService.Enabled = true;
        }

        private void OnStartPending()
        {
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
            labelServiceStatus.Text = "Stan us³ugi: Uruchamianie...";
        }
        private void OnStopPending()
        {
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
            labelServiceStatus.Text = "Stan us³ugi: Zatrzymywanie...";
        }

        private void OnOtherStatus(ServiceControllerStatus result)
        {
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
            labelServiceStatus.Text = "Stan us³ugi: " + result.ToString();
        }

        private void SaveManagerSettings()
        {
            AppSettingsModel model = new AppSettingsModel()
            {
                CheckStatusInterval = Convert.ToInt32(numericUpDownIntervalRefresh.Value),
                OperationTimeout = TimeSpan.FromMilliseconds(Convert.ToDouble(numericOperationTimeout.Value))
            };
            AppSettings.SaveSettings(model);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppSettingsModel model = AppSettings.RestartSettings();
            numericUpDownIntervalRefresh.Value = model.CheckStatusInterval;
            numericOperationTimeout.Value = Convert.ToDecimal(model.OperationTimeout.TotalMilliseconds);
        }
    }
}