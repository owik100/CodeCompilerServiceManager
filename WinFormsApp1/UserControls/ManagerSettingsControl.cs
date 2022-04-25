using CodeCompilerServiceManager.Helpers;
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
        int lastIntervalRefreshValue = 3000;
        int lastOperationTimeoutValue = 3000;
        public ManagerSettingsControl(AppForm appFormParent)
        {
            _appFormParent = appFormParent;
            InitializeComponent();
            BindSettingsToControlls();
            btnSaveManagerSettings.Enabled = false;
        }

        #region controlEvents
        private void checkBoxRefreshEnabled_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveManagerSettings.Enabled = true;
        }
        private void textBoxIntervalRefresh_TextChanged(object sender, EventArgs e)
        {
            btnSaveManagerSettings.Enabled = true;
        }
        private void btnResetManagerSettings_TextChanged(object sender, EventArgs e)
        {
            btnSaveManagerSettings.Enabled = true;
        }
        private void textBoxIntervalRefresh_Leave(object sender, EventArgs e)
        {
            int number;
            if (textBoxIntervalRefresh.Text.All(char.IsDigit))
            {
                if (int.TryParse(textBoxIntervalRefresh.Text, out number))
                {
                    if (number <= 180000)
                    {
                        lastIntervalRefreshValue = Convert.ToInt32(textBoxIntervalRefresh.Text);
                    }
                    else
                    {
                        textBoxIntervalRefresh.Text = "180000";
                        lastIntervalRefreshValue = 180000;
                    }
                }
                else
                {
                    textBoxIntervalRefresh.Text = "180000";
                    lastIntervalRefreshValue = 180000;
                }
            }
            else
            {
                textBoxIntervalRefresh.Text = lastIntervalRefreshValue.ToString();
            }
        }

        private void textBoxIntervalRefresh_KeyPress(object sender, KeyPressEventArgs e)
        {
                e.Handled = TextBoxHelper.PreventLetters(sender, e);
        }

        private void textBoxOperationTimeout_Leave(object sender, EventArgs e)
        {
            int number;
            if (textBoxOperationTimeout.Text.All(char.IsDigit))
            {
                if (int.TryParse(textBoxOperationTimeout.Text, out number))
                {
                    if (number <= 30000)
                    {
                        lastOperationTimeoutValue = Convert.ToInt32(textBoxOperationTimeout.Text);
                    }
                    else
                    {
                        textBoxOperationTimeout.Text = "30000";
                        lastOperationTimeoutValue = 30000;
                    }
                }
                else
                {
                    textBoxOperationTimeout.Text = "30000";
                    lastOperationTimeoutValue = 30000;
                }
            }
            else
            {
                textBoxOperationTimeout.Text = lastOperationTimeoutValue.ToString();
            }
        }

        private void textBoxOperationTimeout_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextBoxHelper.PreventLetters(sender, e);
        }

        private void btnSaveManagerSettings_Click(object sender, EventArgs e)
        {
            try
            {
                AppSettingsModel model = new AppSettingsModel()
                {
                    CheckStatusInterval = Convert.ToInt32(textBoxIntervalRefresh.Text),
                    OperationTimeout = TimeSpan.FromMilliseconds(Convert.ToDouble(textBoxOperationTimeout.Text)),
                    RefreshStatusEnabled = checkBoxRefreshEnabled.Checked,
                };
                AppSettings.SaveSettings(model);

                btnSaveManagerSettings.Enabled = false;
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
                textBoxIntervalRefresh.Text = model.CheckStatusInterval.ToString();
                textBoxOperationTimeout.Text = Convert.ToDecimal(model.OperationTimeout.TotalMilliseconds).ToString();
                checkBoxRefreshEnabled.Checked = model.RefreshStatusEnabled;

                btnSaveManagerSettings.Enabled = false;
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
            textBoxIntervalRefresh.Text = AppSettings.CheckStatusInterval.ToString();
            textBoxOperationTimeout.Text = Convert.ToDecimal(AppSettings.OperationTimeout.TotalMilliseconds).ToString();
            checkBoxRefreshEnabled.Checked = AppSettings.RefreshStatusEnabled;

            lastIntervalRefreshValue = AppSettings.CheckStatusInterval;
            lastOperationTimeoutValue = Convert.ToInt32(AppSettings.OperationTimeout.TotalMilliseconds);
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
