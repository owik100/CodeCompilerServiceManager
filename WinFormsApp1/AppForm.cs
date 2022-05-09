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
        private IUserControlWithSave activeControl;
        private HomeControl homeControl;
        private ConnectionManagerClient communicationManager;

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
        public PictureBox pictureCogAnim { get; private set; }
        public MaterialLabel labelAppFormServiceStatus { get; private set; }
        #endregion

        #region Public Methods
        public void CheckIfFolderInputOutputEmpty()
        {
            try
            {
                if (ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.InputPath != null)
                {
                    if (string.IsNullOrEmpty(ServiceSettings.ServiceSettingsModel.CodeCompilerLibOptions.InputPath))
                    {
                        homeControl.ServiceConnector_MessageHandler(null, new MessageHandlingArgs("Nie podano œcie¿ki do folderu plików wejœciowych do kompilacji!", MessageHandlingLevel.ManagerWarning));
                    }
                }
                if (ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.OutputPath != null)
                {
                    if (string.IsNullOrEmpty(ServiceSettings.ServiceSettingsModel.CodeCompilerLibOptions.OutputPath))
                    {
                        homeControl.ServiceConnector_MessageHandler(null, new MessageHandlingArgs("Nie podano œcie¿ki do folderu wyjœciowego skompilowanych plików!", MessageHandlingLevel.ManagerWarning));
                    }
                }
            }
            catch (Exception ex)
            {
                homeControl.ServiceConnector_MessageHandler(null, new MessageHandlingArgs(ex.Message, MessageHandlingLevel.ManagerError));
            }
        }
        public void InitConnectionCommunicationManager()
        {
            if (ServiceSettings.ServiceSettingsModel?.ServiceOptions?.SendMessagesToManager == true)
            {
                Task.Delay(1000).ContinueWith((task) => {
                    Invoke((MethodInvoker)(() => {
                        communicationManager = new ConnectionManagerClient(ServiceSettings.ServiceSettingsModel.ServiceOptions.SendMessagesPort);
                        communicationManager.GetMessage -= homeControl.ServiceConnector_MessageHandler;
                        communicationManager.GetMessage += homeControl.ServiceConnector_MessageHandler;
                    }));
                });

            }
        }
        public void StopConnectionCommunicationManager()
        {
            communicationManager = null;
        }
        public bool InstallServiceDialog(ref string path)
        {
            bool res = false;
            try
            {
                MaterialDialog materialDialog = new MaterialDialog(this, "Wybór œcie¿ki", "Wybierz folder zawieraj¹cy us³ugê CodeCompilerServiceOwik", "OK", false, "");
                DialogResult dialogResult = materialDialog.ShowDialog(this);
                using (var dialog = new FolderBrowserDialog())
                {
                    DialogResult result = dialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        path = dialog.SelectedPath;
                    }
                    else
                    {
                        return false;
                    }
                }
                res = InstallService(path);
                if (res)
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Us³uga zainstalowana poprawnie!", "OK", false);
                    SnackBarMessage.Show(this);
                    ServiceSettings.LoadSettings(path, false, false);
                    CheckIfFolderInputOutputEmpty();
                }
                else
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("B³¹d. SprawdŸ okno z szczegó³ami na g³ównej zak³adce!", "OK", true);
                    SnackBarMessage.Show(this);
                }
                ReStartService();
            }
            catch (Exception ex)
            {
                homeControl.ServiceConnector_MessageHandler(null, new MessageHandlingArgs(ex.Message ,MessageHandlingLevel.ManagerError));
            }
            return res;
        }
        public void CheckStatus(object sender, EventArgs e)
        {
            ServiceControllerStatus result = serviceConnector.GetServiceStatus();
            homeControl.OnStatusChanged(result);
        }
        public bool ServiceExist()
        {
            return serviceConnector.ServiceExist();
        }
        public bool InstallService(string pathToServiceExe)
        {
            return serviceConnector.InstallService(pathToServiceExe);
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
            InitConnectionCommunicationManager();
            ReStartServiceWorker();
        }
        public void StopService()
        {
            StopConnectionCommunicationManager();
            StopServiceWorker();
        }
        public void StartService()
        {
            InitConnectionCommunicationManager();
            StartServiceWorker();
        }
        #endregion

        #region Private methods
        private void InitColors()
        {
            labelTitleBar.BackColor = ColorManager.PrimaryColor;
        }
        private void InitializeHomeControl()
        {
            homeControl = new HomeControl(this);
            activeControl = homeControl;
            homeControl.GetMessage += homeControl.ServiceConnector_MessageHandler;
        }
        private void InitializeManager()
        {
            try
            {
                string servicePath = GetServicePath();
                AppSettings.GetMessage += homeControl.ServiceConnector_MessageHandler;
                serviceConnector.GetMessage += homeControl.ServiceConnector_MessageHandler;

                LoadManagerOptions();
                InitTimer();
                InitWorkers();
                pictureCogAnim = pictureBoxCogAnim;
                labelAppFormServiceStatus = materialLabelServiceStatus;
                ServiceSettings.GetMessage += homeControl.ServiceConnector_MessageHandler;
                if (string.IsNullOrEmpty(servicePath))
                {
                    homeControl.ServiceConnector_MessageHandler(null, new MessageHandlingArgs("Nie znaleziono œcie¿ki us³ugi!", MessageHandlingLevel.ManagerError));
                    Task.Delay(500).ContinueWith((task) => {
                        Invoke((MethodInvoker)(() => {
                            MaterialDialog materialDialog = new MaterialDialog(this, "Nie znaleziono œcie¿ki us³ugi!", "Wygl¹da na to, ¿e us³uga CodeCompilerServiceOwik nie jest zainstalowana. Chcesz to zrobiæ teraz? (Instalacja dostêpna póŸniej na zak³adce ustawieñ serwisu)", "Tak", true, "Nie");
                            DialogResult dialogResult = materialDialog.ShowDialog(this);
                            if (dialogResult == DialogResult.OK)
                            {
                                InstallServiceDialog(ref servicePath);
                            }
                        }));
                    });
                }
                else
                {
                    LoadServiceSettings(servicePath);
                    CheckIfFolderInputOutputEmpty();
                }
                if (!string.IsNullOrEmpty(servicePath) && serviceConnector.GetServiceStatus() == ServiceControllerStatus.Running)
                {
                    InitConnectionCommunicationManager();
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
                homeControl.ServiceConnector_MessageHandler(null, new MessageHandlingArgs(ex.Message , MessageHandlingLevel.ManagerError));
            }
        }

        private void LoadServiceSettings(string serviceConfigPath)
        {
            ServiceSettings.LoadSettings(serviceConfigPath, true, false);
        }

        private void LoadManagerOptions()
        {
            try
            {
                AppSettingsModel model = AppSettings.LoadSettings();
            }
            catch (Exception ex)
            {
                homeControl.ServiceConnector_MessageHandler(null, new MessageHandlingArgs(ex.Message , MessageHandlingLevel.ManagerError));
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
                homeControl.ServiceConnector_MessageHandler(null, new MessageHandlingArgs(ex.Message , MessageHandlingLevel.ManagerError));
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
        private bool HandleLeaveUcerControl(IUserControlWithSave activeControl)
        {
            if (RestartServiceRequired)
            {
                MaterialDialog materialDialog = new MaterialDialog(this, "Uwaga", "Masz nie zapisane zmiany. Chcesz je zapisaæ? (Us³uga zostanie zrestartowana)", "Zapisz", true, "Anuluj");
                DialogResult dialogResult = materialDialog.ShowDialog(this);

                if (dialogResult == DialogResult.OK)
                {
                    activeControl.SaveChangesOnLeave();
                    return false;
                }
                else if(dialogResult == DialogResult.Cancel)
                {
                    return true;
                }
            }
            RestartServiceRequired = false;
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
        private void materialLabelServiceStatus_SizeChanged(object sender, EventArgs e)
        {
            materialLabelServiceStatus.Left = (panelStatus.Width - materialLabelServiceStatus.Width) / 2;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (!HandleLeaveUcerControl(activeControl))
            {
                if (activeControl.ControlName != homeControl.Name){
                    OpenChildControl(homeControl, sender);
                    activeControl = homeControl;
                }
            }
        }

        private void buttonManagerSettings_Click(object sender, EventArgs e)
        {
            if (!HandleLeaveUcerControl(activeControl))
            {
                if (activeControl.ControlName != "ManagerSettingsControl")
                {
                    ManagerSettingsControl managerSettingsControl = new ManagerSettingsControl(this);
                    OpenChildControl(managerSettingsControl, sender);
                    activeControl = managerSettingsControl;
                    managerSettingsControl.GetMessage -= homeControl.ServiceConnector_MessageHandler;
                    managerSettingsControl.GetMessage += homeControl.ServiceConnector_MessageHandler;
                }
            }
        }

        private void buttonServiceSettings_Click(object sender, EventArgs e)
        {
            if (!HandleLeaveUcerControl(activeControl))
            {
                if (activeControl.ControlName != "ServiceSettingsControl")
                {
                    ServiceSettingsControl serviceSettingsControl = new ServiceSettingsControl(this);
                    OpenChildControl(serviceSettingsControl, sender);
                    activeControl = serviceSettingsControl;
                    serviceSettingsControl.GetMessage -= homeControl.ServiceConnector_MessageHandler;
                    serviceSettingsControl.GetMessage += homeControl.ServiceConnector_MessageHandler;
                }
            }
        }

        private void buttonLibrarySettings_Click(object sender, EventArgs e)
        {
            if (!HandleLeaveUcerControl(activeControl))
            {
                if (activeControl.ControlName != "LibrarySettingsControl")
                {
                    LibrarySettingsControl librarySettingsControl = new LibrarySettingsControl(this);
                    OpenChildControl(librarySettingsControl, sender);
                    activeControl = librarySettingsControl;
                    librarySettingsControl.GetMessage -= homeControl.ServiceConnector_MessageHandler;
                    librarySettingsControl.GetMessage += homeControl.ServiceConnector_MessageHandler;
                }
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            if (!HandleLeaveUcerControl(activeControl))
            {
                if (activeControl.ControlName != "AboutControl")
                {
                    AboutControl aboutControl = new AboutControl();
                    aboutControl.GetMessage -= homeControl.ServiceConnector_MessageHandler;
                    aboutControl.GetMessage += homeControl.ServiceConnector_MessageHandler;

                    OpenChildControl(aboutControl, sender);
                    activeControl = aboutControl;
                }
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
                homeControl.ServiceConnector_MessageHandler(null, new MessageHandlingArgs(ex.Message , MessageHandlingLevel.ManagerError));
            }
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (RestartServiceRequired)
                {
                    MaterialDialog materialDialog = new MaterialDialog(this, "Uwaga", "Masz nie zapisane zmiany. Chcesz je zapisaæ? (Us³uga zostanie zrestartowana)", "Zapisz", true, "Anuluj");
                    DialogResult dialogResult = materialDialog.ShowDialog(this);

                    if (dialogResult == DialogResult.OK)
                    {
                        activeControl.SaveChangesOnLeave();
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                homeControl.ServiceConnector_MessageHandler(null, new MessageHandlingArgs(ex.Message , MessageHandlingLevel.ManagerError));
            }
        }
        #endregion
    }
}