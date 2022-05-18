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
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeCompilerServiceManager.UserControls
{
    public partial class HomeControl : UserControl, IUserControlWithSave, IMeesageHandling
    {
        AppForm _appFormParent;
        public HomeControl(AppForm appFormParent)
        {
            _appFormParent = appFormParent;
            InitializeComponent();
            FixControlPositions();
        }

        #region controlEvents
        private void buttonRefreshServiceState_Click(object sender, EventArgs e)
        {
            try
            {
                _appFormParent.CheckStatus(null, null);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message, MessageHandlingLevel.ManagerError);
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            try
            {
                labelServiceStatus.Text = "Trwa zatrzymywanie usługi...";
                _appFormParent.labelAppFormServiceStatus.Text = "Trwa zatrzymywanie usługi...";
                _appFormParent.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
                _appFormParent.NotifyIcon.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
                _appFormParent.NotifyIcon.Text = "Code Compiler Service Manager - Trwa zatrzymywanie usługi...";
                pictureServiceStatus.Enabled = false;
                _appFormParent.pictureCogAnim.Enabled = false;
                _appFormParent.NotifyIcon.Text = "Code Compiler Service Manager - Stan usługi: Uruchomiona";
                _appFormParent.ContextMenuForNotyIcon.Items[3].Enabled = false;
                _appFormParent.ContextMenuForNotyIcon.Items[4].Enabled = false;
                btnStopService.Enabled = false;
                btnReStartService.Enabled = false;
                _appFormParent.StopService();
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message, MessageHandlingLevel.ManagerError);
            }
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            try
            {
                labelServiceStatus.Text = "Trwa uruchamianie usługi...";
                _appFormParent.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
                _appFormParent.labelAppFormServiceStatus.Text = "Trwa uruchamianie usługi...";
                _appFormParent.NotifyIcon.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
                _appFormParent.NotifyIcon.Text = "Code Compiler Service Manager - Trwa uruchamianie usługi...";
                pictureServiceStatus.Enabled = false;
                _appFormParent.pictureCogAnim.Enabled = false;
                _appFormParent.ContextMenuForNotyIcon.Items[2].Enabled = false;
                _appFormParent.ContextMenuForNotyIcon.Items[4].Enabled = false;
                btnStartService.Enabled = false;
                btnReStartService.Enabled = false;
                _appFormParent.StartService();
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message, MessageHandlingLevel.ManagerError);
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
                OnMessage(ex.Message, MessageHandlingLevel.ManagerError);
            }
        }

        private void btnReStartService_Click(object sender, EventArgs e)
        {
            try
            {
                labelServiceStatus.Text = "Trwa restartowanie usługi...";
                _appFormParent.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
                _appFormParent.labelAppFormServiceStatus.Text = "Trwa restartowanie usługi...";
                _appFormParent.NotifyIcon.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
                _appFormParent.NotifyIcon.Text = "Code Compiler Service Manager - Trwa restartowanie usługi...";
                pictureServiceStatus.Enabled = false;
                _appFormParent.pictureCogAnim.Enabled = false;
                _appFormParent.ContextMenuForNotyIcon.Items[3].Enabled = false;
                _appFormParent.ContextMenuForNotyIcon.Items[4].Enabled = false;
                btnStopService.Enabled = false;
                btnReStartService.Enabled = false;
                _appFormParent.ReStartService();
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message, MessageHandlingLevel.ManagerError);
            }

        }
        private void buttonOpenInputFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFolderPath = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.InputPath;
                if (string.IsNullOrEmpty(inputFolderPath))
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Nie znaleziono ścieżki do folderu wejściowego!", "OK", true);
                    SnackBarMessage.Show(_appFormParent);
                }
                else
                {
                    string argument = "/open, \"" + inputFolderPath + "\"";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message, MessageHandlingLevel.ManagerError);
            }
        }

        private void buttonOpenOutputFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string outputFolderPath = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.OutputPath;
                if (string.IsNullOrEmpty(outputFolderPath))
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Nie znaleziono ścieżki do folderu wyjściowego!", "OK", true);
                    SnackBarMessage.Show(_appFormParent);
                }
                else
                {
                    string argument = "/open, \"" + outputFolderPath + "\"";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message, MessageHandlingLevel.ManagerError);
            }
        }

        private void materialButtonDeleteInputPath_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFolderPath = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.InputPath;
                if (string.IsNullOrEmpty(inputFolderPath))
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Nie znaleziono ścieżki do folderu wejściowego!", "OK", true);
                    SnackBarMessage.Show(_appFormParent);
                }
                else
                {
                    MaterialDialog materialDialog = new MaterialDialog(_appFormParent, "Uwaga", "Czy na pewno chcesz usunąć wszystkie pliki w folderze wejściowym?", "Tak", true, "Nie");
                    DialogResult dialogResult = materialDialog.ShowDialog(this);
                    if (dialogResult == DialogResult.OK)
                    {
                        DirectoryInfo di = new DirectoryInfo(inputFolderPath);
                        var files = di.EnumerateFiles();
                        foreach (FileInfo file in files)
                        {
                            file.Delete();
                        }
                        var directories = di.EnumerateDirectories();
                        foreach (DirectoryInfo dir in directories)
                        {
                            dir.Delete(true);
                        }
                        MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Usunięto pliki!", "OK", true);
                        SnackBarMessage.Show(_appFormParent);
                    }
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message, MessageHandlingLevel.ManagerError);
            }
        }

        private void materialButtonDeleteOutputPath_Click(object sender, EventArgs e)
        {
            try
            {
                string outputFolderPath = ServiceSettings.ServiceSettingsModel?.CodeCompilerLibOptions?.OutputPath;
                if (string.IsNullOrEmpty(outputFolderPath))
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Nie znaleziono ścieżki do folderu wyjściowego!", "OK", true);
                    SnackBarMessage.Show(_appFormParent);
                }
                else
                {
                    MaterialDialog materialDialog = new MaterialDialog(_appFormParent, "Uwaga", "Czy na pewno chcesz usunąć wszystkie pliki w folderze wyjściowym?", "Tak", true, "Nie");
                    DialogResult dialogResult = materialDialog.ShowDialog(this);
                    if (dialogResult == DialogResult.OK)
                    {
                        DirectoryInfo di = new DirectoryInfo(outputFolderPath);
                        var files = di.EnumerateFiles();
                        foreach (FileInfo file in files)
                        {
                            file.Delete();
                        }
                        var directories = di.EnumerateDirectories();
                        foreach (DirectoryInfo dir in directories)
                        {
                            dir.Delete(true);
                        }
                        MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Usunięto pliki!", "OK", true);
                        SnackBarMessage.Show(_appFormParent);
                    }
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message, MessageHandlingLevel.ManagerError);
            }
        }
        private void toolTip1_draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        #endregion

        #region privateMethods
        private void FixControlPositions()
        {
            pictureServiceStatus.Location = new Point((panelStatusInfo.Width - pictureServiceStatus.Width) / 2, pictureServiceStatus.Location.Y);
            labelServiceStatus.Location = new Point((panelStatusInfo.Width - labelServiceStatus.Width) / 2, labelServiceStatus.Location.Y);
            btnClearManagerConsole.Location = new Point((panelClearConsole.Width - btnClearManagerConsole.Width) / 2, btnClearManagerConsole.Location.Y);
            panelServiceButtonContainer.Location = new Point((panelServiceButtons.Width - panelServiceButtonContainer.Width) / 2, panelServiceButtonContainer.Location.Y);
            toolTip1.BackColor = ColorManager.PrimaryColorAccent;
        }
        private void OnStopped()
        {
            pictureServiceStatus.Enabled = false;
            _appFormParent.pictureCogAnim.Enabled = false;
            _appFormParent.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_red;
            labelServiceStatus.Text = "Stan usługi: Zatrzymana";
            _appFormParent.labelAppFormServiceStatus.Text = "Stan usługi: Zatrzymana";
            _appFormParent.NotifyIcon.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_red;
            _appFormParent.NotifyIcon.Text = "Code Compiler Service Manager - Stan usługi: Zatrzymana";
            _appFormParent.ContextMenuForNotyIcon.Items[2].Enabled = true;
            _appFormParent.ContextMenuForNotyIcon.Items[3].Enabled = false;
            btnStartService.Enabled = true;
            btnStopService.Enabled = false;
        }

        private void OnRunning()
        {
            pictureServiceStatus.Enabled = true;
            _appFormParent.pictureCogAnim.Enabled = true;
            _appFormParent.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_green;
            labelServiceStatus.Text = "Stan usługi: Uruchomiona";
            _appFormParent.labelAppFormServiceStatus.Text = "Stan usługi: Uruchomiona";
            _appFormParent.NotifyIcon.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_green;
            _appFormParent.NotifyIcon.Text = "Code Compiler Service Manager - Stan usługi: Uruchomiona";
            _appFormParent.ContextMenuForNotyIcon.Items[2].Enabled = false;
            _appFormParent.ContextMenuForNotyIcon.Items[3].Enabled = true;
            btnStartService.Enabled = false;
            btnStopService.Enabled = true;
        }

        private void OnStartPending()
        {
            pictureServiceStatus.Enabled = false;
            _appFormParent.pictureCogAnim.Enabled = false;
            _appFormParent.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
            labelServiceStatus.Text = "Stan usługi: Uruchamianie...";
            _appFormParent.labelAppFormServiceStatus.Text = "Stan usługi: Uruchamianie...";
            _appFormParent.NotifyIcon.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
            _appFormParent.NotifyIcon.Text = "Code Compiler Service Manager - Stan usługi: Uruchamianie...";
        }
        private void OnStopPending()
        {
            pictureServiceStatus.Enabled = false;
            _appFormParent.pictureCogAnim.Enabled = false;
            _appFormParent.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
            labelServiceStatus.Text = "Stan usługi: Zatrzymywanie...";
            _appFormParent.labelAppFormServiceStatus.Text = "Stan usługi: Zatrzymywanie...";
            _appFormParent.NotifyIcon.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
            _appFormParent.NotifyIcon.Text = "Code Compiler Service Manager - Stan usługi: Zatrzymywanie...";
        }

        private void OnOtherStatus(ServiceControllerStatus result)
        {
            pictureServiceStatus.Enabled = false;
            _appFormParent.pictureCogAnim.Enabled = false;
            _appFormParent.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
            labelServiceStatus.Text = "Stan usługi: " + result.ToString();
            _appFormParent.labelAppFormServiceStatus.Text = "Stan usługi: " + result.ToString();
            _appFormParent.NotifyIcon.Icon = CodeCompilerServiceManager.Properties.Resources.favicon_yellow;
            _appFormParent.labelAppFormServiceStatus.Text = "Code Compiler Service Manager - Stan usługi: " + result.ToString();
        }

        #endregion

        #region publicMethos
        public void OnStatusChanged(ServiceControllerStatus status)
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

        public void ServiceConnector_MessageHandler(object? sender, MessageHandlingArgs messageArgs)
        {
            if (txtOutputConsole.InvokeRequired)
            {
                Action safeWrite = delegate { ServiceConnector_MessageHandler(null, messageArgs); };
                txtOutputConsole.Invoke(safeWrite);
            }
            else
            {
                string textPrefix = "";
                Color textColor = Color.Black;
                bool bold = false;
                switch (messageArgs.Level)
                {
                    case MessageHandlingLevel.ServiceInfo:
                        textPrefix = "[Service Info]";
                        textColor = Color.Black;
                        break;
                    case MessageHandlingLevel.ServiceError:
                        textPrefix = "[Service Error]";
                        textColor = Color.Red;
                        break;
                    case MessageHandlingLevel.ManagerInfo:
                        textPrefix = "[Manager Info]";
                        textColor = Color.Green;
                        break;
                    case MessageHandlingLevel.ManagerWarning:
                        textPrefix = "[Manager Warning]";
                        textColor = Color.Orange;
                        break;
                    case MessageHandlingLevel.ManagerError:
                        textPrefix = "[Manager Error]";
                        textColor = Color.OrangeRed;
                        break;
                    default:
                        break;
                }
                string errMessage = DateTime.Now + " " + $"{textPrefix} - " + " " + messageArgs.Message;

                try
                {
                    txtOutputConsole.AppendText(errMessage, textColor, true, bold);
                }
                catch (Exception ex)
                {

                }
            }
        }
        #endregion

        #region IUserControlWithSave
        public void SaveChangesOnLeave()
        {
            //No changes to save
        }
        string IUserControlWithSave.ControlName => "HomeControl";
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
