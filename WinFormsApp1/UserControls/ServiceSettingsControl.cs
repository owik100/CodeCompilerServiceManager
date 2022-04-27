using CodeCompilerServiceManager.Helpers;
using CodeCompilerServiceManager.Settings;
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
        int lastOperationTimeoutValue = 3000;
        public ServiceSettingsControl(AppForm appFormParent)
        {
            _appFormParent = appFormParent;
            InitializeComponent();
            BindSettingsToControlls();
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = ColorManager.PrimaryColorAccent;
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
                    //ServiceConnector_MessageHandler(null, "Usługa jest już zainstalowana!");
                }
                else
                {
                    MessageBox.Show("Wybierz folder zawierający usługę CodeCompilerServiceOwik", "Wybór ścieżki", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    _appFormParent.InstallService(path);
                    _appFormParent.ReStartService();
                    textBoxServicePath.Text = path;
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
                    DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz odinstalować usługę CodeCompilerServiceOwik?", "Uwaga", MessageBoxButtons.YesNo, icon: MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        bool res = _appFormParent.RemoveService();
                        if (res)
                        {
                            textBoxServicePath.Text = "";
                            _appFormParent.StopService();
                        }
                    }
                    else
                    {
                        return;
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

        private void checkBoxLogToEventViewer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.RestartServiceRequired = true;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
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
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void numericUpDownServiceMainInterval_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.RestartServiceRequired = true;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
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
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void numericUpDownInternalBufferSize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.RestartServiceRequired = true;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
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

                    //BindLibraryOptionsToControls();
                    BindSettingsToControlls();
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
        #endregion

        #region privateMethods
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
                    ServiceSettings.ServiceSettingsModel.ServiceOptions.Interval = (int)numericUpDownServiceMainInterval.Value;
                }
                var bufferSize = ServiceSettings.ServiceSettingsModel?.ServiceOptions?.InternalBufferSize;
                if (bufferSize != null && bufferSize > -1)
                {
                    ServiceSettings.ServiceSettingsModel.ServiceOptions.InternalBufferSize = (int)numericUpDownInternalBufferSize.Value;
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
                    numericUpDownServiceMainInterval.Value = intervalRefresh;
                }

                decimal bufferSize = -1;
                bufferSize = (decimal)(ServiceSettings.ServiceSettingsModel?.ServiceOptions?.InternalBufferSize);
                if (bufferSize > 0)
                {
                    numericUpDownInternalBufferSize.Value = bufferSize;
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
        #endregion

        #region IUserControlWithSave
        public void SaveChangesOnLeave()
        {
            SaveServiceOptions();
        }
        #endregion

        private void textBoxServiceMainInterval_Leave(object sender, EventArgs e)
        {
            int number;
            if (textBoxServiceMainInterval.Text.All(char.IsDigit))
            {
                if (int.TryParse(textBoxServiceMainInterval.Text, out number))
                {
                    if (number <= int.MaxValue)
                    {
                        lastIntervalRefreshValue = Convert.ToInt32(textBoxServiceMainInterval.Text);
                    }
                    else
                    {
                        textBoxServiceMainInterval.Text = int.MaxValue.ToString();
                        lastIntervalRefreshValue = int.MaxValue;
                    }
                }
                else
                {
                    textBoxServiceMainInterval.Text = int.MaxValue.ToString();
                    lastIntervalRefreshValue = int.MaxValue;
                }
            }
            else
            {
                textBoxServiceMainInterval.Text = lastIntervalRefreshValue.ToString();
            }
        }

    }
}
