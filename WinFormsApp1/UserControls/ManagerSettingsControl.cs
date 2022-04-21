using CodeCompilerServiceManager.Settings;
using CodeCompilerServiceManager.Settings.Models;
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
    //TODO handle erros
    public partial class ManagerSettingsControl : UserControl
    {
        AppForm _appFormParent;
        public ManagerSettingsControl(AppForm appFormParent)
        {
            _appFormParent = appFormParent;
            InitializeComponent();
            BindSettingsToControlls();
        }

        #region controlEvents
        private void numericUpDownIntervalRefresh_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                AppSettings.CheckStatusInterval = Convert.ToInt32(numericUpDownIntervalRefresh.Value);
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void numericOperationTimeout_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                AppSettings.OperationTimeout = TimeSpan.FromMilliseconds(Convert.ToDouble(numericOperationTimeout.Value));
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
        private void btnSaveManagerSettings_Click(object sender, EventArgs e)
        {
            try
            {
                AppSettingsModel model = new AppSettingsModel()
                {
                    CheckStatusInterval = Convert.ToInt32(numericUpDownIntervalRefresh.Value),
                    OperationTimeout = TimeSpan.FromMilliseconds(Convert.ToDouble(numericOperationTimeout.Value)),
                    RefreshStatusEnabled = checkBoxRefreshEnabled.Checked,
                };
                AppSettings.SaveSettings(model);

                AfterSettingsChanged();
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
        private void btnResetManagerSettings_Click(object sender, EventArgs e)
        {
            try
            {
                AppSettingsModel model = AppSettings.RestartSettings();
                numericUpDownIntervalRefresh.Value = model.CheckStatusInterval;
                numericOperationTimeout.Value = Convert.ToDecimal(model.OperationTimeout.TotalMilliseconds);
                checkBoxRefreshEnabled.Checked = model.RefreshStatusEnabled;

                AfterSettingsChanged();
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }
        #endregion

        #region privateMethods
        private void BindSettingsToControlls()
        {
            numericUpDownIntervalRefresh.Value = AppSettings.CheckStatusInterval;
            numericOperationTimeout.Value = Convert.ToDecimal(AppSettings.OperationTimeout.TotalMilliseconds);
            checkBoxRefreshEnabled.Checked = AppSettings.RefreshStatusEnabled;
        }
        private void AfterSettingsChanged()
        {
            if (_appFormParent.ServiceStatusTimer != null)
            {
                _appFormParent.ServiceStatusTimer.Enabled = checkBoxRefreshEnabled.Checked;
            }

            if (_appFormParent.ServiceStatusTimer != null)
            {
                _appFormParent.ServiceStatusTimer.Interval = AppSettings.CheckStatusInterval;
            }

            if (checkBoxRefreshEnabled.Checked)
            {
                _appFormParent.CheckStatus(null, null);
            }
        }
        #endregion
    }
}
