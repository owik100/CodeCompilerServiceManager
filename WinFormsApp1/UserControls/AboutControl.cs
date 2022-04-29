using CodeCompilerServiceManager.Helpers;
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
    public partial class AboutControl : UserControl, IUserControlWithSave
    {
        //TODO error handling
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
        #endregion


        #region eventControls
        private void materialButtonLinkManager_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer", "https://github.com/owik100/CodeCompilerServiceManager");
            }
            catch (Exception ex)
            {

            }
        }
        private void materialButtonLinkService_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer", "https://github.com/owik100/CoderCompilerWorkerService");
            }
            catch (Exception ex)
            {

            }

        }
        private void materialButtonLinkSLibrary_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer", "https://github.com/owik100/CodeCompilerLibrary");
            }
            catch (Exception ex)
            {

            }
        }

        private void materialButtonLinkMaterilSkin_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer", "https://github.com/leocb/MaterialSkin");
            }
            catch (Exception ex)
            {

            }
        }
        private void pictureBoxOwikLogo_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer", "https://owik100.github.io/Portfolio/");
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region IUserControlWithSave
        public void SaveChangesOnLeave()
        {
            //No changes to save
        }




        #endregion


    }
}
