using CodeCompilerServiceManager.Helpers;
using CodeCompilerServiceManager.Logic;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeCompilerServiceManager.UserControls
{
    public partial class AboutControl : UserControl, IUserControlWithSave, IMeesageHandling
    {
        public AboutControl()
        {
            InitializeComponent();
            InitialAppVersion();
        }

        #region privateMethods
        private void InitialAppVersion()
        {
            string versionNumber = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
            materialLabelApplicationVersion.Text = "Code compiler manager v. " + versionNumber;
        }

        private void GoToLink(string link)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer", link);
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Błąd. Sprawdź okno z szczegółami na głównej zakładce!", "OK", true);
                SnackBarMessage.Show(this);
            }
        }
        #endregion


        #region eventControls
        private void materialButtonLinkManager_Click(object sender, EventArgs e)
        {
                GoToLink("https://github.com/owik100/CodeCompilerServiceManager");
        }
        private void materialButtonLinkService_Click(object sender, EventArgs e)
        {
            GoToLink("https://github.com/owik100/CoderCompilerWorkerService");
        }
        private void materialButtonLinkSLibrary_Click(object sender, EventArgs e)
        {
            GoToLink("https://github.com/owik100/CodeCompilerLibrary");
        }

        private void materialButtonLinkMaterilSkin_Click(object sender, EventArgs e)
        {
            GoToLink("https://github.com/leocb/MaterialSkin");
        }
        private void pictureBoxOwikLogo_Click(object sender, EventArgs e)
        {
            GoToLink("https://owik100.github.io/Portfolio/");
        }
        private void materialButtonBasicReferenceAssemblies_Click(object sender, EventArgs e)
        {
            GoToLink("https://github.com/jaredpar/basic-reference-assemblies");
        }
        #endregion

        #region IUserControlWithSave
        public void SaveChangesOnLeave()
        {
            //No changes to save
        }
        string IUserControlWithSave.ControlName => "AboutControl";
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
