using CodeCompilerServiceConfig.Logic;
using CodeCompilerServiceManager.Settings;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ServiceProcess;
using CodeCompilerService.OptionModels;
using CodeCompilerServiceManager.Settings.Models;

namespace CodeCompilerServiceManager
{
    public partial class AppForm : Form
    {
        ServiceProxy serviceConnector = new ServiceProxy();
        ServiceSettings serviceSettings;

        private System.Windows.Forms.Timer serviceStatusTimer;
        private BackgroundWorker workerOnStart;
        private BackgroundWorker workerOnStop;
        private BackgroundWorker workerOnRestart;

        private bool restartRequired = false;

        public AppForm()
        {
            InitializeComponent();
            AppSettings.GetMessage += ServiceConnector_MessageHandler;
            serviceConnector.GetMessage += ServiceConnector_MessageHandler;
            LoadOptions();
            labelServiceStatus.Text = "Stan us³ugi: Nieznany...";
            InitTimer();
            InitWorkers();
            string servisePath = serviceConnector.GetServicePath();
            if (string.IsNullOrEmpty(servisePath))
            {
                ServiceConnector_MessageHandler(null, "Nie znaleziono œcie¿ki us³ugi!");
            }
            else
            {
                textBoxServicePath.Text = servisePath;
                serviceSettings = new ServiceSettings(servisePath);

                PrepareLibOptions();
                PrepareServiceOptions();
            }
            if (checkBoxRefreshEnabled.Checked)
            {
                CheckStatus(null, null);
            }
        }

        private void PrepareServiceOptions()
        {
            //2 way binding?
            bool saveToEventLog = false;
            var settingExist = serviceSettings?.ServiceSettingsModel?.Serilog?.WriteTo?.Where(x => x.Name == "EventLog")?.FirstOrDefault();
            if(settingExist != null)
            {
                saveToEventLog = true;
            }

            checkBoxLogToEventViewer.Checked = saveToEventLog;

            bool saveToFile = false;
            settingExist = null;
            settingExist = serviceSettings?.ServiceSettingsModel?.Serilog?.WriteTo?.Where(x => x.Name == "File")?.FirstOrDefault();
            if (settingExist != null)
            {
                saveToFile = true;
            }

            checkBoxLogToFile.Checked = saveToFile;

            string pathToFileLog = "";
            pathToFileLog = serviceSettings?.ServiceSettingsModel?.Serilog?.WriteTo?.Where(x => x.Name == "File")?.FirstOrDefault()?.Args?.path;
            if (!String.IsNullOrEmpty(pathToFileLog))
            {
                textBoxPathToLogs.Text = pathToFileLog;
            }

            decimal intervalRefresh = -1;
            intervalRefresh = (decimal)(serviceSettings?.ServiceSettingsModel?.ServiceOptions?.Interval);
            if (intervalRefresh > 0)
            {
                numericUpDownServiceMainInterval.Value = intervalRefresh;
            }

            decimal bufferSize = -1;
            bufferSize = (decimal)(serviceSettings?.ServiceSettingsModel?.ServiceOptions?.InternalBufferSize);
            if (bufferSize > 0)
            {
                numericUpDownInternalBufferSize.Value = bufferSize;
            }

        }

        private void PrepareLibOptions()
        {
            string pathToInput = "";
            pathToInput = serviceSettings?.ServiceSettingsModel?.CodeCompilerLibOptions?.InputPath;
            if (!String.IsNullOrEmpty(pathToInput))
            {
                textBoxInputPath.Text = pathToInput;
            }

            string pathToOutput = "";
            pathToOutput = serviceSettings?.ServiceSettingsModel?.CodeCompilerLibOptions?.OutputPath;
            if (!String.IsNullOrEmpty(pathToOutput))
            {
                textBoxOutputPath.Text = pathToOutput;
            }

            bool? compileToConsoleApp = false;
            compileToConsoleApp = serviceSettings?.ServiceSettingsModel?.CodeCompilerLibOptions?.BuildToConsoleApp;
            if (compileToConsoleApp == null)
                compileToConsoleApp = false;

            checkBoxCompileToConsoleApp.Checked = (bool)compileToConsoleApp;
        }

        private void LoadOptions()
        {
            AppSettingsModel model = AppSettings.LoadSettings();
            numericUpDownIntervalRefresh.Value = model.CheckStatusInterval;
            numericOperationTimeout.Value = Convert.ToDecimal(model.OperationTimeout.TotalMilliseconds);
            checkBoxRefreshEnabled.Checked = model.RefreshStatusEnabled;
        }

        private void InitTimer()
        {
            serviceStatusTimer = new System.Windows.Forms.Timer();
            serviceStatusTimer.Tick += new EventHandler(CheckStatus);
            serviceStatusTimer.Interval = AppSettings.CheckStatusInterval;
            if (checkBoxRefreshEnabled.Checked)
            {
                serviceStatusTimer.Start();
            }

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

        private void btnSaveManagerSettings_Click(object sender, EventArgs e)
        {
            AppSettingsModel model = new AppSettingsModel()
            {
                CheckStatusInterval = Convert.ToInt32(numericUpDownIntervalRefresh.Value),
                OperationTimeout = TimeSpan.FromMilliseconds(Convert.ToDouble(numericOperationTimeout.Value)),
                RefreshStatusEnabled = checkBoxRefreshEnabled.Checked,
            };
            AppSettings.SaveSettings(model);
        }

        private void numericUpDownIntervalRefresh_ValueChanged(object sender, EventArgs e)
        {
            AppSettings.CheckStatusInterval = Convert.ToInt32(numericUpDownIntervalRefresh.Value);
            if (serviceStatusTimer != null)
            {
                serviceStatusTimer.Interval = AppSettings.CheckStatusInterval;
            }
            SaveManagerSettings();
        }

        private void numericOperationTimeout_ValueChanged(object sender, EventArgs e)
        {
            AppSettings.OperationTimeout = TimeSpan.FromMilliseconds(Convert.ToDouble(numericOperationTimeout.Value));
            SaveManagerSettings();
        }

        #endregion

        private void ServiceConnector_MessageHandler(object? sender, string errorMessage)
        {
            if (txtOutputConsole.InvokeRequired)
            {
                Action safeWrite = delegate { ServiceConnector_MessageHandler(null, errorMessage); };
                txtOutputConsole.Invoke(safeWrite);
            }
            else
            {
                string errMessage = DateTime.Now + " " + "[ServiceManager] - " + " " + errorMessage;
                txtOutputConsole.ForeColor = Color.Red;
                txtOutputConsole.Text += errMessage;
                txtOutputConsole.Text += Environment.NewLine;

            }
        }

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
                OperationTimeout = TimeSpan.FromMilliseconds(Convert.ToDouble(numericOperationTimeout.Value)),
                RefreshStatusEnabled = checkBoxRefreshEnabled.Checked,
            };
            AppSettings.SaveSettings(model);
        }

        private void btnResetManagerSettings_Click(object sender, EventArgs e)
        {
            AppSettingsModel model = AppSettings.RestartSettings();
            numericUpDownIntervalRefresh.Value = model.CheckStatusInterval;
            numericOperationTimeout.Value = Convert.ToDecimal(model.OperationTimeout.TotalMilliseconds);
            checkBoxRefreshEnabled.Checked = model.RefreshStatusEnabled;
        }

        private void btnClearManagerConsole_Click(object sender, EventArgs e)
        {
            txtOutputConsole.Clear();
        }

        private void checkBoxRefreshEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (serviceStatusTimer != null)
            {
                serviceStatusTimer.Enabled = checkBoxRefreshEnabled.Checked;
            }

            if (checkBoxRefreshEnabled.Checked)
            {
                CheckStatus(null, null);
            }
            SaveManagerSettings();
        }

        private void buttonInstallService_Click(object sender, EventArgs e)
        {
            string path = serviceConnector.InstallService();
            if (!string.IsNullOrEmpty(path))
            {
                textBoxServicePath.Text = path;
            }
        }

        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            bool res = serviceConnector.RemoveService();
            if (res)
            {
                textBoxServicePath.Text = "";
            }
        }

        private void buttonAppRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void buttonOpenLogFolder_Click(object sender, EventArgs e)
        {
            //TODO wczytanie jsona konfigu na start
            string serviceConfigPath = textBoxServicePath.Text;
            if (string.IsNullOrEmpty(serviceConfigPath))
            {
                ServiceConnector_MessageHandler(null, "Nie znaleziono œcie¿ki us³ugi!");
            }
            else
            {
                string path = serviceSettings?.ServiceSettingsModel?.Serilog?.WriteTo.Where(x => x.Name == "File").FirstOrDefault()?.Args?.path;
                if (string.IsNullOrWhiteSpace(path))
                {
                    ServiceConnector_MessageHandler(null, "Nie znaleziono œcie¿ki do logów w opcjach!");
                }
                else
                {
                    string argument = "/select, \"" + path + "\"";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
            }
        }

        private void buttonRefreshServiceState_Click(object sender, EventArgs e)
        {
            CheckStatus(null, null);
        }
    }
}