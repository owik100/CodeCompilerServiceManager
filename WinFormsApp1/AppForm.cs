using CodeCompilerServiceManager.Logic;
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
        IServiceProxy serviceConnector = new ServiceProxy();
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
            LoadManagerOptions();
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
                serviceSettings = new ServiceSettings(servisePath, false);
                serviceSettings.GetMessage += ServiceConnector_MessageHandler;

                BindLibraryOptionsToControls();
                BindServiceOptionsToControls();
            }
            if (checkBoxRefreshEnabled.Checked)
            {
                CheckStatus(null, null);
            }

            restartRequired = false;
            labelRestartRequired.Visible = restartRequired;
        }

        #region Private methods
        private void BindServiceOptionsToControls()
        {
            //2 way binding?
            bool saveToEventLog = false;
            var settingExist = serviceSettings?.ServiceSettingsModel?.Serilog?.WriteTo?.Where(x => x.Name == "EventLog")?.FirstOrDefault();
            if (settingExist != null)
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
            if (pathToFileLog != null)
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
        private void BindLibraryOptionsToControls()
        {
            string pathToInput = "";
            pathToInput = serviceSettings?.ServiceSettingsModel?.CodeCompilerLibOptions?.InputPath;
            if (pathToInput != null)
            {
                textBoxInputPath.Text = pathToInput;
            }

            string pathToOutput = "";
            pathToOutput = serviceSettings?.ServiceSettingsModel?.CodeCompilerLibOptions?.OutputPath;
            if (pathToOutput != null)
            {
                textBoxOutputPath.Text = pathToOutput;
            }

            bool? compileToConsoleApp = false;
            compileToConsoleApp = serviceSettings?.ServiceSettingsModel?.CodeCompilerLibOptions?.BuildToConsoleApp;
            if (compileToConsoleApp == null)
                compileToConsoleApp = false;

            checkBoxCompileToConsoleApp.Checked = (bool)compileToConsoleApp;
        }
        private void LoadManagerOptions()
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
        private void SaveServiceAndLibraryOptions()
        {
            //Serilog
            var WriteToEventLog = serviceSettings?.ServiceSettingsModel?.Serilog?.WriteTo?.FirstOrDefault(x => x?.Name == "EventLog" || x?.Name == "EventLogOff");
            if (WriteToEventLog != null)
            {
                if (checkBoxLogToEventViewer.Checked)
                {
                    WriteToEventLog.Name = "EventLog";
                }
                else
                {
                    WriteToEventLog.Name = "EventLogOFF";
                }
            }

            var WriteToFile = serviceSettings?.ServiceSettingsModel?.Serilog?.WriteTo?.FirstOrDefault(x => x?.Name == "File" || x?.Name == "FileOFF");
            if (WriteToFile != null)
            {
                if (checkBoxLogToFile.Checked)
                {
                    WriteToFile.Name = "File";
                }
                else
                {
                    WriteToFile.Name = "FileOFF";
                }

                WriteToFile.Args.path = textBoxPathToLogs.Text;
            }


            //Service options
            var serviceInterval = serviceSettings?.ServiceSettingsModel?.ServiceOptions?.Interval;
            if (serviceInterval != null && serviceInterval > -1)
            {
                serviceSettings.ServiceSettingsModel.ServiceOptions.Interval = (int)numericUpDownServiceMainInterval.Value;
            }
            var bufferSize = serviceSettings?.ServiceSettingsModel?.ServiceOptions?.InternalBufferSize;
            if (bufferSize != null && bufferSize > -1)
            {
                serviceSettings.ServiceSettingsModel.ServiceOptions.InternalBufferSize = (int)numericUpDownInternalBufferSize.Value;
            }


            //Library options
            var libInputPath = serviceSettings?.ServiceSettingsModel?.CodeCompilerLibOptions?.InputPath;
            if (libInputPath != null)
            {
                serviceSettings.ServiceSettingsModel.CodeCompilerLibOptions.InputPath = textBoxInputPath.Text;
            }

            var libOutputtPath = serviceSettings?.ServiceSettingsModel?.CodeCompilerLibOptions?.OutputPath;
            if (libOutputtPath != null)
            {
                serviceSettings.ServiceSettingsModel.CodeCompilerLibOptions.OutputPath = textBoxOutputPath.Text;
            }

            var compileToWindowConsole = serviceSettings?.ServiceSettingsModel?.CodeCompilerLibOptions?.BuildToConsoleApp;
            if (compileToWindowConsole != null)
            {
                serviceSettings.ServiceSettingsModel.CodeCompilerLibOptions.BuildToConsoleApp = checkBoxCompileToConsoleApp.Checked;
            }

            serviceSettings.SaveSettingsToJson(textBoxServicePath.Text);
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
            restartRequired = false;
            labelRestartRequired.Visible = restartRequired;
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
            restartRequired = false;
            labelRestartRequired.Visible = restartRequired;
        }
        #endregion


        #region formEvents
        private void btnStartService_Click(object sender, EventArgs e)
        {
            labelServiceStatus.Text = "Trwa uruchamianie us³ugi...";
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
            btnStartService.Enabled = false;
            btnReStartService.Enabled = false;
            if (restartRequired)
            {
                SaveServiceAndLibraryOptions();
            }
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
            if (restartRequired)
            {
                SaveServiceAndLibraryOptions();
            }
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
                textBoxServicePath.Text = path;
            }
        }

        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            if (serviceConnector.ServiceExist())
            {
                DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz odinstalowaæ us³ugê CodeCompilerServiceOwik?", "Uwaga", MessageBoxButtons.YesNo, icon: MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    bool res = serviceConnector.RemoveService();
                    if (res)
                    {
                        textBoxServicePath.Text = "";
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

        private void buttonAppRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void buttonOpenLogFolder_Click(object sender, EventArgs e)
        {
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

        private void checkBoxLogToEventViewer_CheckedChanged(object sender, EventArgs e)
        {
            restartRequired = true;
            labelRestartRequired.Visible = restartRequired;
        }

        private void checkBoxLogToFile_CheckedChanged(object sender, EventArgs e)
        {
            restartRequired = true;
            labelRestartRequired.Visible = restartRequired;
        }

        private void textBoxPathToLogs_TextChanged(object sender, EventArgs e)
        {
            restartRequired = true;
            labelRestartRequired.Visible = restartRequired;
        }

        private void numericUpDownServiceMainInterval_ValueChanged(object sender, EventArgs e)
        {
            restartRequired = true;
            labelRestartRequired.Visible = restartRequired;
        }

        private void numericUpDownInternalBufferSize_ValueChanged(object sender, EventArgs e)
        {
            restartRequired = true;
            labelRestartRequired.Visible = restartRequired;
        }

        private void textBoxInputPath_TextChanged(object sender, EventArgs e)
        {
            restartRequired = true;
            labelRestartRequired.Visible = restartRequired;
        }

        private void textBoxOutputPath_TextChanged(object sender, EventArgs e)
        {
            restartRequired = true;
            labelRestartRequired.Visible = restartRequired;
        }

        private void checkBoxCompileToConsoleApp_CheckedChanged(object sender, EventArgs e)
        {
            restartRequired = true;
            labelRestartRequired.Visible = restartRequired;
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (restartRequired)
            {
                //Info ze wymagany restart po zmianach, jak tak zapisz zmiany zrob restart uslugi i wyjdz,
                //jak nie wyjdz bez zapisywania, jak anuluj nie rob nic
            }
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


        private void buttonSaveAndRestart_Click(object sender, EventArgs e)
        {
            //Zapisz i zrestartuj usluge
            SaveServiceAndLibraryOptions();
            btnReStartService_Click(null, null);

        }

        private void buttonCancelChanges_Click(object sender, EventArgs e)
        {
            //Wczytaj jsona i zdeserializuj
            string servisePath = serviceConnector.GetServicePath();
            if (string.IsNullOrEmpty(servisePath))
            {
                ServiceConnector_MessageHandler(null, "Nie znaleziono œcie¿ki us³ugi!");
            }
            else
            {
                textBoxServicePath.Text = servisePath;
                serviceSettings = new ServiceSettings(servisePath, false);

                BindLibraryOptionsToControls();
                BindServiceOptionsToControls();
                restartRequired = false;
                labelRestartRequired.Visible = restartRequired;
            }
        }

        private void buttonSetDefaultServiceSettings_Click(object sender, EventArgs e)
        {
            string servisePath = serviceConnector.GetServicePath();
            if (string.IsNullOrEmpty(servisePath))
            {
                ServiceConnector_MessageHandler(null, "Nie znaleziono œcie¿ki us³ugi!");
            }
            else
            {
                textBoxServicePath.Text = servisePath;
                serviceSettings = new ServiceSettings(servisePath, true);

                BindLibraryOptionsToControls();
                BindServiceOptionsToControls();
                restartRequired = false;
                labelRestartRequired.Visible = restartRequired;

                buttonSaveAndRestart_Click(null, null);
            }
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

    }
}