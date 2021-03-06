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
    public partial class LibrarySettingsControl : UserControl, IUserControlWithSave, IMeesageHandling
    {
        AppForm _appFormParent;
        public LibrarySettingsControl(AppForm appFormParent)
        {
            _appFormParent = appFormParent;
            InitializeComponent();
            SetComboBoxNetVersionItems();
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

        private void SetComboBoxNetVersionItems()
        {
            Dictionary<string, string> comboDictionary = new Dictionary<string, string>();
            comboDictionary.Add("Net461", ".NET Framework 4.6.1");
            comboDictionary.Add("Net472", ".NET Framework 4.7.2");
            comboDictionary.Add("NetStandard13", ".NET Standard 1.3");
            comboDictionary.Add("NetStandard20", ".NET Standard 2.0");
            comboDictionary.Add("NetCoreApp31", ".NET Core 3.1");
            comboDictionary.Add("Net50", ".NET 5");
            comboDictionary.Add("Net60", ".NET 6");
            materialComboBoxNetVersion.DataSource = new BindingSource(comboDictionary, null);
            materialComboBoxNetVersion.DisplayMember = "Value";
            materialComboBoxNetVersion.ValueMember = "Key";
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

                string buildType = "";
                buildType = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.BuildType;

                materialRadioButtonMakeDll.Checked = buildType == "DynamicallyLinkedLibrary";
                materialRadioButtonMakeExe.Checked = buildType == "ConsoleApplication";

                string netVerison = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.NetVersionToCompile;

                foreach (var item in materialComboBoxNetVersion.Items)
                {
                    var comboItem = (KeyValuePair< string, string>)item;
                    if (comboItem.Key.Equals(netVerison))
                        materialComboBoxNetVersion.SelectedItem = comboItem;
                }
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

                var compileToWindowConsole = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.BuildType;
                if (compileToWindowConsole != null)
                {
                    string res = "";
                    if (materialRadioButtonMakeExe.Checked)
                    {
                        res = "ConsoleApplication";
                    }
                    else
                    {
                        res = "DynamicallyLinkedLibrary";
                    }
                    ServiceSettings.ServiceSettingsModel.CodeCompilerLibOptions.BuildType = res;
                }

                ServiceSettings.ServiceSettingsModel.CodeCompilerLibOptions.NetVersionToCompile = ((KeyValuePair<string, string>)materialComboBoxNetVersion.SelectedItem).Key;

                string servisePath = _appFormParent.GetServicePath();
                if (!string.IsNullOrEmpty(servisePath))
                {
                    ServiceSettings.SaveSettingsToJson(servisePath);
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

        #region controlEvents

        private void materialComboBoxNetVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.RestartServiceRequired = true;
                labelRestartRequired.Visible = _appFormParent.RestartServiceRequired;
                SetButtonEnabledStatus(true);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message, MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
            }
        }
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
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
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
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
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
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
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
                    ServiceSettings.LoadSettings(servisePath, true, false);
                    BindSettingsToControlls();
                    SetButtonEnabledStatus(false);
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
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
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
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(_appFormParent);
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
        #region IMeesageHandling

        public event EventHandler<MessageHandlingArgs> GetMessage;
        protected virtual void OnMessage(string message, MessageHandlingLevel level)
        {
            GetMessage?.Invoke(this, new MessageHandlingArgs(message, level));
        }
        #endregion

    }

}
