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
    public partial class ServiceSettingsControl : UserControl
    {
        AppForm _appFormParent;
        public ServiceSettingsControl(AppForm appFormParent)
        {
            _appFormParent = appFormParent;
            InitializeComponent();
            BindSettingsToControlls();
        }

        #region controlEvenets

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
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
            _appFormParent.RestartServiceRequired = false;
            labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
        }
        #endregion
    }
}
