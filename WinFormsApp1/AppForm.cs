using CodeCompilerServiceManager.Logic;
using CodeCompilerServiceManager.Settings;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ServiceProcess;
using CodeCompilerService.OptionModels;
using CodeCompilerServiceManager.Settings.Models;
using CodeCompilerServiceManager.Helpers;
using CodeCompilerServiceManager.UserControls;

namespace CodeCompilerServiceManager
{
    public partial class AppForm : Form
    {
        IServiceProxy serviceConnector = new ServiceProxy();

        private BackgroundWorker workerOnStart;
        private BackgroundWorker workerOnStop;
        private BackgroundWorker workerOnRestart;

        private Button currentMenuButton;
        private Form activeForm;

        public AppForm()
        {
            InitializeComponent();
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
            OnStatusChanged(result);
        }
        public void SetRestartRequiredState()
        {
            RestartServiceRequired = true;
            labelRestartRequired.Visible = RestartServiceRequired;
        }
        public string GetServicePath()
        {
            return serviceConnector.GetServicePath();
        }
        public void ReStartService()
        {
            btnReStartService_Click(null, null);
        }
        #endregion

        #region Private methods
        private void InitializeManager()
        {
            try
            {
                ActiveNavButton(buttonHome);
                AppSettings.GetMessage += ServiceConnector_MessageHandler;
                serviceConnector.GetMessage += ServiceConnector_MessageHandler;
                LoadManagerOptions();
                InitTimer();
                InitWorkers();
                labelServiceStatus.Text = "Stan us³ugi: Nieznany...";
                string servicePath = GetServicePath();
                if (string.IsNullOrEmpty(servicePath))
                {
                    ServiceConnector_MessageHandler(null, "Nie znaleziono œcie¿ki us³ugi!");
                }
                else
                {
                    LoadServiceSettings(servicePath);
                    ServiceSettings.GetMessage += ServiceConnector_MessageHandler;

                    BindLibraryOptionsToControls();
                }
                if (AppSettings.RefreshStatusEnabled)
                {
                    CheckStatus(null, null);
                }
                RestartServiceRequired = false;
                labelRestartRequired.Visible = RestartServiceRequired;
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void LoadServiceSettings(string serviceConfigPath)
        {
            ServiceSettings.LoadSettings(serviceConfigPath, false);
        }
        private void BindLibraryOptionsToControls()
        {
            try
            {
                string pathToInput = "";
                pathToInput = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.InputPath;
                if (pathToInput != null)
                {
                    textBoxInputPath.Text = pathToInput;
                }

                string pathToOutput = "";
                pathToOutput = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.OutputPath;
                if (pathToOutput != null)
                {
                    textBoxOutputPath.Text = pathToOutput;
                }

                bool? compileToConsoleApp = false;
                compileToConsoleApp = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.BuildToConsoleApp;
                if (compileToConsoleApp == null)
                    compileToConsoleApp = false;

                checkBoxCompileToConsoleApp.Checked = (bool)compileToConsoleApp;
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
            
        }
        private void LoadManagerOptions()
        {
            try
            {
                AppSettingsModel model = AppSettings.LoadSettings();
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
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
                ServiceConnector_MessageHandler(null, ex.ToString());
            }

        }
        //TODO impleemt
        private void SaveLibraryOptions()
        {

        }

        private void SaveServiceAndLibraryOptions()
        {
            try
            {
              

                //Library options
                var libInputPath = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.InputPath;
                if (libInputPath != null)
                {
                    ServiceSettings.ServiceSettingsModel.CodeCompilerLibOptions.InputPath = textBoxInputPath.Text;
                }

                var libOutputtPath = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.OutputPath;
                if (libOutputtPath != null)
                {
                    ServiceSettings.ServiceSettingsModel.CodeCompilerLibOptions.OutputPath = textBoxOutputPath.Text;
                }

                var compileToWindowConsole = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.BuildToConsoleApp;
                if (compileToWindowConsole != null)
                {
                    ServiceSettings.ServiceSettingsModel.CodeCompilerLibOptions.BuildToConsoleApp = checkBoxCompileToConsoleApp.Checked;
                }

                ServiceSettings.SaveSettingsToJson(GetServicePath());
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
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

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActiveNavButton(btnSender);
            activeForm = childForm;

            activeForm.TopLevel = false;
            ActiveForm.FormBorderStyle = FormBorderStyle.None;
            ActiveForm.Dock = DockStyle.Fill;
            this.panelDesktopParent.Controls.Add(childForm);
            this.panelDesktopParent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
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
                if(btn.GetType() == typeof(Button))
                {
                    btn.BackColor = ColorManager.BackColorSidePanel;
                    btn.ForeColor = Color.Gainsboro;
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
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
            OnStatusChanged((ServiceControllerStatus)Convert.ToInt32(e.Result));
            RestartServiceRequired = false;
            labelRestartRequired.Visible = RestartServiceRequired;
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
            RestartServiceRequired = false;
            labelRestartRequired.Visible = RestartServiceRequired;
        }
        #endregion

        #region formEvents

        private void buttonHome_Click(object sender, EventArgs e)
        {
            ActiveNavButton(sender);
        }

        private void buttonManagerSettings_Click(object sender, EventArgs e)
        {
            OpenChildControl(new ManagerSettingsControl(this), sender);
        }

        private void buttonServiceSettings_Click(object sender, EventArgs e)
        {
            OpenChildControl(new ServiceSettingsControl(this), sender);
        }

        private void buttonLibrarySettings_Click(object sender, EventArgs e)
        {

        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            OpenChildControl(new AboutControl(), sender);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            try
            {
                labelServiceStatus.Text = "Trwa uruchamianie us³ugi...";
                pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
                btnStartService.Enabled = false;
                btnReStartService.Enabled = false;
                if (RestartServiceRequired)
                {
                    SaveServiceAndLibraryOptions();
                }
                workerOnStart.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            try
            {
                labelServiceStatus.Text = "Trwa zatrzymywanie us³ugi...";
                pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
                btnStopService.Enabled = false;
                btnReStartService.Enabled = false;
                workerOnStop.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void btnReStartService_Click(object sender, EventArgs e)
        {
            try
            {
                labelServiceStatus.Text = "Trwa restartowanie us³ugi...";
                pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
                btnStopService.Enabled = false;
                btnReStartService.Enabled = false;
                if (RestartServiceRequired)
                {
                    SaveServiceAndLibraryOptions();
                }
                workerOnRestart.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }

        }

        private void buttonInstallService_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                if (serviceConnector.ServiceExist())
                {
                    ServiceConnector_MessageHandler(null, "Us³uga jest ju¿ zainstalowana!");
                }
                else
                {
                    MessageBox.Show("Wybierz folder zawieraj¹cy us³ugê CodeCompilerServiceOwik", "Wybór œcie¿ki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (var dialog = new FolderBrowserDialog())
                    {
                        DialogResult result = dialog.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            path = dialog.SelectedPath;
                        }
                        else
                        {
                            return;
                        }
                    }
                    serviceConnector.InstallService(path);
                    //textBoxServicePath.Text = path;
                    btnReStartService_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceConnector.ServiceExist())
                {
                    DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz odinstalowaæ us³ugê CodeCompilerServiceOwik?", "Uwaga", MessageBoxButtons.YesNo, icon: MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        bool res = serviceConnector.RemoveService();
                        if (res)
                        {
                            //textBoxServicePath.Text = "";
                            btnStopService_Click(null, null);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    ServiceConnector_MessageHandler(null, "Us³uga nie jest zainstalowana!");
                }
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void buttonAppRestart_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Restart();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void buttonRefreshServiceState_Click(object sender, EventArgs e)
        {
            try
            {
                CheckStatus(null, null);
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void textBoxInputPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetRestartRequiredState();
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void textBoxOutputPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetRestartRequiredState();
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void checkBoxCompileToConsoleApp_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SetRestartRequiredState();
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
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
                        btnReStartService_Click(null, null);
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
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void btnClearManagerConsole_Click(object sender, EventArgs e)
        {
            try
            {
                txtOutputConsole.Clear();
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }


        private void buttonSaveAndRestart_Click(object sender, EventArgs e)
        {
            try
            {
                SaveServiceAndLibraryOptions();
                btnReStartService_Click(null, null);
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void buttonCancelChanges_Click(object sender, EventArgs e)
        {
            try
            {
                string servisePath = serviceConnector.GetServicePath();
                if (string.IsNullOrEmpty(servisePath))
                {
                    ServiceConnector_MessageHandler(null, "Nie znaleziono œcie¿ki us³ugi!");
                }
                else
                {
                    ServiceSettings.LoadSettings(servisePath, false);

                    BindLibraryOptionsToControls();
                    RestartServiceRequired = false;
                    labelRestartRequired.Visible = RestartServiceRequired;
                }
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void buttonSetDefaultServiceSettings_Click(object sender, EventArgs e)
        {
            try
            {
                string servisePath = serviceConnector.GetServicePath();
                if (string.IsNullOrEmpty(servisePath))
                {
                    ServiceConnector_MessageHandler(null, "Nie znaleziono œcie¿ki us³ugi!");
                }
                else
                {
                    ServiceSettings.LoadSettings(servisePath, true);

                    BindLibraryOptionsToControls();
                    RestartServiceRequired = false;
                    labelRestartRequired.Visible = RestartServiceRequired;

                    buttonSaveAndRestart_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
        #endregion
    }
}