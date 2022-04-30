using CodeCompilerServiceManager.Helpers;
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
    //TODO error handling
    //TODO podczas zapisywania  zmian wczytac ustawienia z library i je podpiac
    public partial class ServiceSettingsControl : UserControl, IUserControlWithSave
    {
        AppForm _appFormParent;
        int lastIntervalRefreshValue = 10000;
        int lastInternalBufferSize = 8192;
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
        private void buttonOpenServicePath_Click(object sender, EventArgs e)
        {
            try
            {
                if (_appFormParent.ServiceExist())
                {
                    string path = _appFormParent.GetServicePath();
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        //ServiceConnector_MessageHandler(null, "Nie znaleziono ścieżki do logów w opcjach!");
                    }
                    else
                    {
                        string argument = "/select, \"" + path + "\"";
                        System.Diagnostics.Process.Start("explorer.exe", argument);
                    }
                }
                else
                {
                     //ServiceConnector_MessageHandler(null, "Usługa nie jest zainstalowana!");
                }
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
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
                    SnackBarMessage.Show(this);
                }
                else
                {
                    bool res = _appFormParent.InstallServiceDialog(ref path);
                    textBoxServicePath.Text = path;
                    if (res)
                    {
                        SetButtonsInstallService(false);
                    }
                }
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
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
                            SnackBarMessage.Show(this);
                            SetButtonsInstallService(true);
                        }
                        else
                        {
                            MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                            SnackBarMessage.Show(this);
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
                    SnackBarMessage.Show(this);
                }
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
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
                //ServiceConnector_MessageHandler(null, ex.ToString());
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
                //ServiceConnector_MessageHandler(null, ex.ToString());
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
                //ServiceConnector_MessageHandler(null, ex.ToString());
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
                //ServiceConnector_MessageHandler(null, ex.ToString());
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
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
        private void buttonOpenLogFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceConfigPath = textBoxServicePath.Text;
                if (string.IsNullOrEmpty(serviceConfigPath))
                {
                    //ServiceConnector_MessageHandler(null, "Nie znaleziono ścieżki usługi!");
                }
                else
                {
                    string path = ServiceSettings.ServiceSettingsModel?.Serilog?.WriteTo.Where(x => x.Name == "File").FirstOrDefault()?.Args?.path;
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        //ServiceConnector_MessageHandler(null, "Nie znaleziono ścieżki do logów w opcjach!");
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
               //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void buttonSaveAndRestart_Click(object sender, EventArgs e)
        {
            try
            {
                SaveServiceOptions();
                _appFormParent.ReStartService();
                _appFormParent.RestartServiceRequired = false;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
                SetButtonEnabledStatus(false);
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }


        private void buttonCancelChanges_Click(object sender, EventArgs e)
        {
            try
            {
                string servisePath = _appFormParent.GetServicePath();
                if (string.IsNullOrEmpty(servisePath))
                {
                    //ServiceConnector_MessageHandler(null, "Nie znaleziono ścieżki usługi!");
                }
                else
                {
                    textBoxServicePath.Text = servisePath;
                    ServiceSettings.LoadSettings(servisePath, false);
                    BindSettingsToControlls();
                    SetButtonEnabledStatus(false);
                }
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
        private void buttonSetDefaultServiceSettings_Click(object sender, EventArgs e)
        {
            try
            {
                string servisePath = _appFormParent.GetServicePath();
                if (string.IsNullOrEmpty(servisePath))
                {
                    //ServiceConnector_MessageHandler(null, "Nie znaleziono ścieżki usługi!");
                }
                else
                {
                    textBoxServicePath.Text = servisePath;
                    ServiceSettings.LoadSettings(servisePath, true);

                    BindSettingsToControlls();
                    buttonSaveAndRestart_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
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

                ServiceSettings.SaveSettingsToJson(textBoxServicePath.Text);
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
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

                string pathToFileLog = "";
                pathToFileLog = ServiceSettings.ServiceSettingsModel?.Serilog?.WriteTo?.Where(x => x.Name == "File")?.FirstOrDefault()?.Args?.path;
                if (pathToFileLog != null)
                {
                    textBoxPathToLogs.Text = pathToFileLog;
                }

                decimal intervalRefresh = -1;
                intervalRefresh = (decimal)(ServiceSettings.ServiceSettingsModel?.ServiceOptions?.Interval);
                if (intervalRefresh > 0)
                {
                    textBoxServiceMainInterval.Text = intervalRefresh.ToString();
                    lastIntervalRefreshValue = (int)intervalRefresh;
                }

                decimal bufferSize = -1;
                bufferSize = (decimal)(ServiceSettings.ServiceSettingsModel?.ServiceOptions?.InternalBufferSize);
                if (bufferSize > 0)
                {
                    textBoxInternalBufferSize.Text = bufferSize.ToString();
                }

                lastIntervalRefreshValue = (int)intervalRefresh;
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
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




    }
}
