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
    public partial class LibrarySettingsControl : UserControl, IUserControlWithSave
    {
        AppForm _appFormParent;
        public LibrarySettingsControl(AppForm appFormParent)
        {
            _appFormParent = appFormParent;
            InitializeComponent();
            BindSettingsToControlls();
            SetButtonEnabledStatus(false);
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = ColorManager.PrimaryColorAccent;
        }

        #region privateMethods
        private void SetButtonEnabledStatus(bool enabled)
        {
            buttonSaveAndRestart.Enabled = enabled;
            buttonCancelChanges.Enabled = enabled;
        }

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

                materialRadioButtonMakeDll.Checked = !(bool)compileToConsoleApp;
                materialRadioButtonMakeExe.Checked = (bool)compileToConsoleApp;
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
                    ServiceSettings.ServiceSettingsModel.CodeCompilerLibOptions.BuildToConsoleApp = materialRadioButtonMakeExe.Checked;
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
                SetButtonEnabledStatus(true);
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

        private void textBoxOutputPath_TextChanged(object sender, EventArgs e)
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

        private void materialRadioButtonMakeDll_CheckedChanged(object sender, EventArgs e)
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

        private void materialRadioButtonMakeExe_CheckedChanged(object sender, EventArgs e)
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

        private void buttonSaveAndRestart_Click(object sender, EventArgs e)
        {
            try
            {
                SaveLibraryOptions();
                _appFormParent.pictureCogAnim.Enabled = false;
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
                    ServiceSettings.LoadSettings(servisePath, true);

                    BindSettingsToControlls();
                    _appFormParent.pictureCogAnim.Enabled = false;
                    buttonSaveAndRestart_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
        private void materialButtonChooseInputFolder_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    DialogResult result = dialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        textBoxInputPath.Text = dialog.SelectedPath;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void materialButtonChooseOutputFolder_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    DialogResult result = dialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        textBoxOutputPath.Text = dialog.SelectedPath;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
        private void textBoxInputPath_Enter(object sender, EventArgs e)
        {
            textBoxInputPath.SelectionStart = textBoxInputPath.Text.Length;
            textBoxInputPath.SelectionLength = 0;
        }

        private void textBoxOutputPath_Enter(object sender, EventArgs e)
        {
            textBoxOutputPath.SelectionStart = textBoxOutputPath.Text.Length;
            textBoxOutputPath.SelectionLength = 0;
        }
        #endregion

        #region IUserControlWithSave
        public void SaveChangesOnLeave()
        {
            buttonSaveAndRestart_Click(null, null);
        }
        string IUserControlWithSave.ControlName => "LibrarySettingsControl";
        #endregion
    }
    
}
