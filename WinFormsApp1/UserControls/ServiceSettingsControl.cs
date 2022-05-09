using CodeCompilerServiceManager.Helpers;
using CodeCompilerServiceManager.Logic;
using CodeCompilerServiceManager.Settings;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeCompilerServiceManager.UserControls
{
    public partial class ServiceSettingsControl : UserControl, IUserControlWithSave, IMeesageHandling
    {
        AppForm _appFormParent;
        int lastIntervalRefreshValue = 10000;
        int lastInternalBufferSize = 8192;
        int lastPort = 3055;
        public ServiceSettingsControl(AppForm appFormParent)
        {
            _appFormParent = appFormParent;
            InitializeComponent();
            BindSettingsToControlls();
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = ColorManager.PrimaryColorAccent;
            SetButtonEnabledStatus(false);
            InitButtonsInstallService();
        }

        #region controlEvenets
        private void materialButtonFindFreePort_Click(object sender, EventArgs e)
        {
            materialTextBoxPortForManagerSendMessages.Text = ConnectionManagerClient.FindFreeTcpPort().ToString();
        }
        private void buttonOpenServicePath_Click(object sender, EventArgs e)
        {
            try
            {
                if (_appFormParent.ServiceExist())
                {
                    string path = _appFormParent.GetServicePath();
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        OnMessage("Nie znaleziono ścieżki do logów w opcjach!", MessageHandlingLevel.ManagerError);
                        MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                        SnackBarMessage.Show(_appFormParent);
                    }
                    else
                    {
                        string argument = "/select, \"" + path + "\"";
                        System.Diagnostics.Process.Start("explorer.exe", argument);
                    }
                }
                else
                {
                    OnMessage("Usługa nie jest zainstalowana!", MessageHandlingLevel.ManagerError);
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                    SnackBarMessage.Show(_appFormParent);
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }
        private void buttonInstallService_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                if (_appFormParent.ServiceExist())
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Usługa jest już zainstalowana!", "OK", true);
                    SnackBarMessage.Show(_appFormParent);
                }
                else
                {
                    bool res = _appFormParent.InstallServiceDialog(ref path);
                    textBoxServicePath.Text = path;
                    if (res)
                    {
                        SetButtonsInstallService(false);
                        ServiceSettings.LoadSettings(path, false, false);
                        BindSettingsToControlls();
                    }
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }

        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            try
            {
                if (_appFormParent.ServiceExist())
                {
                    MaterialDialog materialDialog = new MaterialDialog(_appFormParent, "Uwaga", "Czy na pewno chcesz odinstalować usługę CodeCompilerServiceOwik?", "Tak", true, "Nie");
                    DialogResult dialogResult = materialDialog.ShowDialog(this);
                    if (dialogResult == DialogResult.OK)
                    {
                        bool res = _appFormParent.RemoveService();
                        if (res)
                        {
                            textBoxServicePath.Text = "";
                            _appFormParent.StopService();

                            MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Usługa usunięta poprawnie!", "OK", false);
                            SnackBarMessage.Show(_appFormParent);
                            SetButtonsInstallService(true);
                        }
                        else
                        {
                            MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                            SnackBarMessage.Show(_appFormParent);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Usługa nie jest zainstalowana!", "OK", true);
                    SnackBarMessage.Show(_appFormParent);
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }

        private void checkBoxLogToEventViewer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.RestartServiceRequired = true;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
                SetButtonEnabledStatus(true);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }

        private void checkBoxLogToFile_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.RestartServiceRequired = true;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
                SetButtonEnabledStatus(true);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }
        private void checkBoxSendMessagesToManager_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.RestartServiceRequired = true;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
                SetButtonEnabledStatus(true);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }

        private void textBoxPathToLogs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.RestartServiceRequired = true;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
                SetButtonEnabledStatus(true);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }

        private void textBoxServiceMainInterval_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.RestartServiceRequired = true;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
                SetButtonEnabledStatus(true);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }

        private void textBoxInternalBufferSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.RestartServiceRequired = true;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
                SetButtonEnabledStatus(true);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }

        private void materialTextBoxPortForManagerSendMessages_Enter(object sender, EventArgs e)
        {
            materialTextBoxPortForManagerSendMessages.SelectionStart = materialTextBoxPortForManagerSendMessages.Text.Length;
            materialTextBoxPortForManagerSendMessages.SelectionLength = 0;
        }

        private void materialTextBoxPortForManagerSendMessages_Leave(object sender, EventArgs e)
        {
            try
            {
                int number;
                if (materialTextBoxPortForManagerSendMessages.Text.All(char.IsDigit))
                {
                    if (int.TryParse(materialTextBoxPortForManagerSendMessages.Text, out number))
                    {
                        if (number < 1)
                        {
                            materialTextBoxPortForManagerSendMessages.Text = 1.ToString();
                            lastPort = 1;
                        }
                        else if (number <= 65536)
                        {
                            lastPort = Convert.ToInt32(materialTextBoxPortForManagerSendMessages.Text);
                        }
                        else
                        {
                            materialTextBoxPortForManagerSendMessages.Text = 65536.ToString();
                            lastPort = 65536;
                        }
                    }
                    else
                    {
                        materialTextBoxPortForManagerSendMessages.Text = 65536.ToString();
                        lastPort = 65536;
                    }
                }
                else
                {
                    materialTextBoxPortForManagerSendMessages.Text = lastPort.ToString();
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }

        private void materialTextBoxPortForManagerSendMessages_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextBoxHelper.PreventLetters(sender, e);
        }

        private void materialTextBoxPortForManagerSendMessages_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.RestartServiceRequired = true;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
                SetButtonEnabledStatus(true);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }
        private void buttonOpenLogFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceConfigPath = textBoxServicePath.Text;
                if (string.IsNullOrEmpty(serviceConfigPath))
                {
                    OnMessage("Nie znaleziono ścieżki usługi!", MessageHandlingLevel.ManagerError);
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                    SnackBarMessage.Show(_appFormParent);
                }
                else
                {
                    string path = ServiceSettings.ServiceSettingsModel?.Serilog?.WriteTo.Where(x => x.Name == "File").FirstOrDefault()?.Args?.path;
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        OnMessage("Nie znaleziono ścieżki do logów w opcjach!", MessageHandlingLevel.ManagerError);
                        MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                        SnackBarMessage.Show(_appFormParent);
                    }
                    else
                    {
                        string argument = "/select, \"" + path + "\"";
                        System.Diagnostics.Process.Start("explorer.exe", argument);
                    }
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }

        private void buttonSaveAndRestart_Click(object sender, EventArgs e)
        {
            try
            {
                SaveServiceOptions();
                _appFormParent.pictureCogAnim.Enabled = false;
                _appFormParent.ReStartService();
                _appFormParent.RestartServiceRequired = false;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
                SetButtonEnabledStatus(false);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }


        private void buttonCancelChanges_Click(object sender, EventArgs e)
        {
            try
            {
                string servisePath = _appFormParent.GetServicePath();
                if (string.IsNullOrEmpty(servisePath))
                {
                    OnMessage("Nie znaleziono ścieżki usługi!", MessageHandlingLevel.ManagerError);
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                    SnackBarMessage.Show(_appFormParent);
                }
                else
                {
                    textBoxServicePath.Text = servisePath;
                    ServiceSettings.LoadSettings(servisePath,true, false);
                    BindSettingsToControlls();
                    SetButtonEnabledStatus(false);
                    _appFormParent.CheckIfFolderInputOutputEmpty();
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }
        private void buttonSetDefaultServiceSettings_Click(object sender, EventArgs e)
        {
            try
            {
                string servisePath = _appFormParent.GetServicePath();
                if (string.IsNullOrEmpty(servisePath))
                {
                    OnMessage("Nie znaleziono ścieżki usługi!", MessageHandlingLevel.ManagerError);
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                    SnackBarMessage.Show(_appFormParent);
                }
                else
                {
                    textBoxServicePath.Text = servisePath;
                    ServiceSettings.LoadSettings(servisePath, true, true);

                    BindSettingsToControlls();
                    _appFormParent.pictureCogAnim.Enabled = false;
                    buttonSaveAndRestart_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }
        private void toolTip1_draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
        private void textBoxPathToLogs_Enter(object sender, EventArgs e)
        {
            textBoxPathToLogs.SelectionStart = textBoxPathToLogs.Text.Length;
            textBoxPathToLogs.SelectionLength = 0;
        }
        private void textBoxServiceMainInterval_Enter(object sender, EventArgs e)
        {
            textBoxServiceMainInterval.SelectionStart = textBoxServiceMainInterval.Text.Length;
            textBoxServiceMainInterval.SelectionLength = 0;
        }

        private void textBoxInternalBufferSize_Enter(object sender, EventArgs e)
        {
            textBoxInternalBufferSize.SelectionStart = textBoxInternalBufferSize.Text.Length;
            textBoxInternalBufferSize.SelectionLength = 0;
        }
        private void textBoxServiceMainInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextBoxHelper.PreventLetters(sender, e);
        }

        private void textBoxInternalBufferSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextBoxHelper.PreventLetters(sender, e);
        }

        private void textBoxServiceMainInterval_Leave(object sender, EventArgs e)
        {
            try
            {
                int number;
                if (textBoxServiceMainInterval.Text.All(char.IsDigit))
                {
                    if (int.TryParse(textBoxServiceMainInterval.Text, out number))
                    {
                        if (number < 50)
                        {
                            textBoxServiceMainInterval.Text = 50.ToString();
                            lastIntervalRefreshValue = 50;
                        }
                        else if (number <= 43200000)
                        {
                            lastIntervalRefreshValue = Convert.ToInt32(textBoxServiceMainInterval.Text);
                        }
                        else
                        {
                            textBoxServiceMainInterval.Text = 43200000.ToString();
                            lastIntervalRefreshValue = 43200000;
                        }
                    }
                    else
                    {
                        textBoxServiceMainInterval.Text = 43200000.ToString();
                        lastIntervalRefreshValue = 43200000;
                    }
                }
                else
                {
                    textBoxServiceMainInterval.Text = lastIntervalRefreshValue.ToString();
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }

        private void textBoxInternalBufferSize_Leave(object sender, EventArgs e)
        {
            try
            {
                int number;
                if (textBoxInternalBufferSize.Text.All(char.IsDigit))
                {
                    if (int.TryParse(textBoxServiceMainInterval.Text, out number))
                    {
                        if (number < 100)
                        {
                            textBoxInternalBufferSize.Text = 100.ToString();
                            lastInternalBufferSize = 100;
                        }
                        else if (number <= 43200000)
                        {
                            lastInternalBufferSize = Convert.ToInt32(textBoxInternalBufferSize.Text);
                        }
                        else
                        {
                            textBoxInternalBufferSize.Text = 43200000.ToString();
                            lastInternalBufferSize = 43200000;
                        }
                    }
                    else
                    {
                        textBoxInternalBufferSize.Text = 43200000.ToString();
                        lastInternalBufferSize = 43200000;
                    }
                }
                else
                {
                    textBoxInternalBufferSize.Text = lastInternalBufferSize.ToString();
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }
        #endregion

        #region privateMethods
        private void InitButtonsInstallService()
        {
            if (_appFormParent.ServiceExist())
            {
                buttonInstallService.Enabled = false;
                buttonDeleteService.Enabled = true;
            }
            else
            {
                buttonInstallService.Enabled = true;
                buttonDeleteService.Enabled = false;
            }
        }
        private void SetButtonsInstallService(bool canInstall)
        {
            buttonInstallService.Enabled = canInstall;
            buttonDeleteService.Enabled = !canInstall;
        }
        private void SaveServiceOptions()
        {
            try
            {
                //Serilog
                var WriteToEventLog = ServiceSettings.ServiceSettingsModel?.Serilog?.WriteTo?.FirstOrDefault(x => x?.Name == "EventLog" || x?.Name == "EventLogOff");
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

                var WriteToFile = ServiceSettings.ServiceSettingsModel?.Serilog?.WriteTo?.FirstOrDefault(x => x?.Name == "File" || x?.Name == "FileOFF");
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
                var serviceInterval = ServiceSettings.ServiceSettingsModel?.ServiceOptions?.Interval;
                if (serviceInterval != null && serviceInterval > -1)
                {
                    ServiceSettings.ServiceSettingsModel.ServiceOptions.Interval = Convert.ToInt32(textBoxServiceMainInterval.Text);
                }
                var bufferSize = ServiceSettings.ServiceSettingsModel?.ServiceOptions?.InternalBufferSize;
                if (bufferSize != null && bufferSize > -1)
                {
                    ServiceSettings.ServiceSettingsModel.ServiceOptions.InternalBufferSize = Convert.ToInt32(textBoxInternalBufferSize.Text);
                }

                ServiceSettings.ServiceSettingsModel.ServiceOptions.SendMessagesToManager = checkBoxSendMessagesToManager.Checked;

                var sendMessagesPort = ServiceSettings.ServiceSettingsModel?.ServiceOptions?.SendMessagesPort;
                if (sendMessagesPort != null && sendMessagesPort > -1)
                {
                    ServiceSettings.ServiceSettingsModel.ServiceOptions.SendMessagesPort = Convert.ToInt32(materialTextBoxPortForManagerSendMessages.Text);
                }

                ServiceSettings.SaveSettingsToJson(textBoxServicePath.Text);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }
        private void BindSettingsToControlls()
        {
            string servicePath = _appFormParent.GetServicePath();
            textBoxServicePath.Text = servicePath;
            labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
            try
            {
                bool saveToEventLog = false;
                var settingExist = ServiceSettings.ServiceSettingsModel?.Serilog?.WriteTo?.Where(x => x.Name == "EventLog")?.FirstOrDefault();
                if (settingExist != null)
                {
                    saveToEventLog = true;
                }

                checkBoxLogToEventViewer.Checked = saveToEventLog;

                bool saveToFile = false;
                settingExist = null;
                settingExist = ServiceSettings.ServiceSettingsModel?.Serilog?.WriteTo?.Where(x => x.Name == "File")?.FirstOrDefault();
                if (settingExist != null)
                {
                    saveToFile = true;
                }

                checkBoxLogToFile.Checked = saveToFile;

                bool? sendToManager = false;
                sendToManager = ServiceSettings.ServiceSettingsModel?.ServiceOptions?.SendMessagesToManager;
                if (sendToManager == null)
                    sendToManager = false;
                checkBoxSendMessagesToManager.Checked = (bool)sendToManager;

                string pathToFileLog = "";
                pathToFileLog = ServiceSettings.ServiceSettingsModel?.Serilog?.WriteTo?.Where(x => x.Name == "File")?.FirstOrDefault()?.Args?.path;
                if (pathToFileLog != null)
                {
                    textBoxPathToLogs.Text = pathToFileLog;
                }

                decimal sendToManagerPort = -1;
                var sendToManagerPortRes = ServiceSettings.ServiceSettingsModel?.ServiceOptions?.SendMessagesPort;
                if (sendToManagerPortRes != null)
                {
                    sendToManagerPort = (decimal)sendToManagerPortRes;
                    materialTextBoxPortForManagerSendMessages.Text = sendToManagerPort.ToString();
                    lastPort = (int)sendToManagerPort;
                }

                decimal intervalRefresh = -1;
                var intervalRefreshRes = ServiceSettings.ServiceSettingsModel?.ServiceOptions?.Interval;
                if (intervalRefreshRes != null)
                {
                    intervalRefresh = (decimal)intervalRefreshRes;
                    textBoxServiceMainInterval.Text = intervalRefresh.ToString();
                    lastIntervalRefreshValue = (int)intervalRefresh;
                }

                decimal bufferSize = -1;
                var bufferSizeRes = ServiceSettings.ServiceSettingsModel?.ServiceOptions?.InternalBufferSize;
                if (bufferSizeRes != null)
                {
                    bufferSize = (decimal)bufferSizeRes;
                    textBoxInternalBufferSize.Text = bufferSize.ToString();
                }

                lastIntervalRefreshValue = (int)intervalRefresh;
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
            _appFormParent.RestartServiceRequired = false;
            labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
        }
        private void SetButtonEnabledStatus(bool enabled)
        {
            buttonSaveAndRestart.Enabled = enabled;
            buttonCancelChanges.Enabled = enabled;
        }
        #endregion

        #region IUserControlWithSave
        public void SaveChangesOnLeave()
        {
            buttonSaveAndRestart_Click(null, null);
        }
        string IUserControlWithSave.ControlName => "ServiceSettingsControl";
        #endregion

        #region IMeesageHandling

        public event EventHandler<MessageHandlingArgs> GetMessage;
        protected virtual void OnMessage(string message, MessageHandlingLevel level)
        {
            GetMessage?.Invoke(this, new MessageHandlingArgs(message, level));
        }

        #endregion
    }
}