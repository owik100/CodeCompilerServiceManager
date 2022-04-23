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
    public partial class AboutControl : UserControl
    {
        //TODO error handling
        public AboutControl()
        {
            InitializeComponent();
        }

        #region eventControls
        private void linkLabelGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer", "https://github.com/owik100/CodeCompilerServiceManager");
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

    }
}
