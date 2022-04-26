using CodeCompilerServiceManager.Logic;
using CodeCompilerServiceManager.Settings;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ServiceProcess;
using CodeCompilerService.OptionModels;
using CodeCompilerServiceManager.Settings.Models;
using CodeCompilerServiceManager.Helpers;
using CodeCompilerServiceManager.UserControls;
using MaterialSkin.Controls;

namespace CodeCompilerServiceManager
{
    public partial class AppForm : MaterialForm
    {
        IServiceProxy serviceConnector = new ServiceProxy();

        private BackgroundWorker workerOnStart;
        private BackgroundWorker workerOnStop;
        private BackgroundWorker workerOnRestart;

        private Button currentMenuButton;
        private Form activeForm;
        private HomeControl homeControl;

        public AppForm()
        {
            InitializeComponent();
            InitColors();
            InitializeHomeControl();
            InitializeManager();
        }

        #region Properties
        public System.Windows.Forms.Timer ServiceStatusTimer { get; private set; }
        public bool RestartServiceRequired { get; set; } = false;
        #endregion

        #region Public Methods
        public void CheckStatus(object sender, EventArgs e)
        {
            ServiceControllerStatus result = serviceConnector.GetServiceStatus();
            homeControl.OnStatusChanged(result);
        }
        public bool ServiceExist()
        {
            return serviceConnector.ServiceExist();
        }
        public void InstallService(string pathToServiceExe)
        {
            serviceConnector.InstallService(pathToServiceExe);
        }
        public bool RemoveService()
        {
            return serviceConnector.RemoveService();
        }
        public string GetServicePath()
        {
            return serviceConnector.GetServicePath();
        }
        public void ReStartService()
        {
            ReStartServiceWorker();
        }
        public void StopService()
        {
            StopServiceWorker();
        }
        public void StartService()
        {
            StartServiceWorker();
        }
        #endregion

        #region Private methods
        private void InitColors()
        {
            //panelLogo.BackColor = ColorManager.PrimaryColorAccent;
            labelTitleBar.BackColor = ColorManager.PrimaryColor;
        }
        private void InitializeHomeControl()
        {
            homeControl = new HomeControl(this);
        }
        private void InitializeManager()
        {
            try
            {
                AppSettings.GetMessage += homeControl.ServiceConnector_MessageHandler;
                serviceConnector.GetMessage += homeControl.ServiceConnector_MessageHandler;
                LoadManagerOptions();
                InitTimer();
                InitWorkers();
                string servicePath = GetServicePath();
                if (string.IsNullOrEmpty(servicePath))
                {
                    homeControl.ServiceConnector_MessageHandler(null, "Nie znaleziono œcie¿ki us³ugi!");
                }
                else
                {
                    LoadServiceSettings(servicePath);
                    ServiceSettings.GetMessage += homeControl.ServiceConnector_MessageHandler;
                }
                if (AppSettings.RefreshStatusEnabled)
                {
                    CheckStatus(null, null);
                }
                RestartServiceRequired = false;
                OpenChildControl(homeControl, buttonHome);
            }
            catch (Exception ex)
            {
                homeControl.ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void LoadServiceSettings(string serviceConfigPath)
        {
            ServiceSettings.LoadSettings(serviceConfigPath, false);
        }

        private void LoadManagerOptions()
        {
            try
            {
                AppSettingsModel model = AppSettings.LoadSettings();
            }
            catch (Exception ex)
            {
                homeControl.ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
        private void InitTimer()
        {
            try
            {
                ServiceStatusTimer = new System.Windows.Forms.Timer();
                ServiceStatusTimer.Tick += new EventHandler(CheckStatus);
                ServiceStatusTimer.Interval = AppSettings.CheckStatusInterval;
                if (AppSettings.RefreshStatusEnabled)
                {
                    ServiceStatusTimer.Start();
                }
            }
            catch (Exception ex)
            {
                homeControl.ServiceConnector_MessageHandler(null, ex.ToString());
            }

        }

        private void StartServiceWorker()
        {
            workerOnStart.RunWorkerAsync();
        }

        private void StopServiceWorker()
        {
            workerOnStop.RunWorkerAsync();
        }

        private void ReStartServiceWorker()
        {
            workerOnRestart.RunWorkerAsync();
        }

        private void ActiveNavButton(object btnSender)
        {
            DisableNavButtons();
            if (btnSender != null && (Button)btnSender != currentMenuButton)
            {
                currentMenuButton = (Button)btnSender;
                currentMenuButton.BackColor = ColorManager.PrimaryColor;
                currentMenuButton.ForeColor = Color.White;
                currentMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                labelTitleBar.Text = ((Button)btnSender).Text;
            }
        }

        private void OpenChildControl(UserControl childControl, object btnSender)
        {
            this.panelDesktopParent.Controls.Clear();
            ActiveNavButton(btnSender);

            this.panelDesktopParent.Controls.Add(childControl);
            childControl.Dock = DockStyle.Fill;
        }

        private void DisableNavButtons()
        {
            foreach (Control btn in panelSideMenu.Controls)
            {
                if (btn.GetType() == typeof(Button))
                {
                    btn.BackColor = ColorManager.BackColorSidePanel;
                    btn.ForeColor = Color.Gainsboro;
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }


        /// <returns>True means, we want cancel changing user control</returns>
        private bool HandleLeaveUcerControl()
        {
            if (RestartServiceRequired)
            {
                DialogResult dialogResult = MessageBox.Show("Masz nie zapisane zmiany. Chcesz je zapisaæ? (Us³uga zostanie zrestartowana)", "Uwaga", MessageBoxButtons.YesNoCancel, icon: MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    //Zrobic zapis na kontrolce serwisu/biblioteki
                    return false;
                }
                else if (dialogResult == DialogResult.No)
                {
                    return false;
                }
                else if(dialogResult == DialogResult.Cancel)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

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
            homeControl.OnStatusChanged((ServiceControllerStatus)Convert.ToInt32(e.Result));
            RestartServiceRequired = false;
        }

        private void workerOnRestart_DoWork(object? sender, DoWorkEventArgs e)
        {
            e.Result = serviceConnector.RestartService();
        }

        private void workerOnStop_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            homeControl.OnStatusChanged((ServiceControllerStatus)Convert.ToInt32(e.Result));
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
            homeControl.OnStatusChanged((ServiceControllerStatus)Convert.ToInt32(e.Result));
            RestartServiceRequired = false;
        }
        #endregion

        #region formEvents

        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (!HandleLeaveUcerControl())
            {
                OpenChildControl(homeControl, sender);
            }
        }

        private void buttonManagerSettings_Click(object sender, EventArgs e)
        {
            if (!HandleLeaveUcerControl())
            {
                OpenChildControl(new ManagerSettingsControl(this), sender);
            }
        }

        private void buttonServiceSettings_Click(object sender, EventArgs e)
        {
            if (!HandleLeaveUcerControl())
            {
                OpenChildControl(new ServiceSettingsControl(this), sender);
            }
        }

        private void buttonLibrarySettings_Click(object sender, EventArgs e)
        {
            if (!HandleLeaveUcerControl())
            {
                OpenChildControl(new LibrarySettingsControl(this), sender);
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            if (!HandleLeaveUcerControl())
            {
                OpenChildControl(new AboutControl(), sender);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Restart();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                homeControl.ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (RestartServiceRequired)
                {
                    DialogResult dialogResult = MessageBox.Show("Masz nie zapisane zmiany. Chcesz je zapisaæ? (Us³uga zostanie zrestartowana)", "Uwaga", MessageBoxButtons.YesNoCancel, icon: MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ReStartServiceWorker();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                homeControl.ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
        #endregion
    }
}