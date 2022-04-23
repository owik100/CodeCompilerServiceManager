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
    public partial class LibrarySettingsControl : UserControl
    {
        AppForm _appFormParent;
        public LibrarySettingsControl(AppForm appFormParent)
        {
            _appFormParent = appFormParent;
            InitializeComponent();
            BindSettingsToControlls();
        }

        #region privateMethods
        private void BindSettingsToControlls()
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
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
            _appFormParent.RestartServiceRequired = false;
            labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
        }

        private void SaveLibraryOptions()
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

                string servisePath = _appFormParent.GetServicePath();
                if (!string.IsNullOrEmpty(servisePath))
                {
                    ServiceSettings.SaveSettingsToJson(servisePath);
                }
            }

            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
        #endregion

        #region controlEvents
        private void textBoxInputPath_TextChanged(object sender, EventArgs e)
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

        private void textBoxOutputPath_TextChanged(object sender, EventArgs e)
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

        private void checkBoxCompileToConsoleApp_CheckedChanged(object sender, EventArgs e)
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

        private void buttonSaveAndRestart_Click(object sender, EventArgs e)
        {
            try
            {
                SaveLibraryOptions();
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
                    ServiceSettings.LoadSettings(servisePath, false);
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
    }
}
