﻿using System;
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
    //TODO error handle
    public partial class HomeControl : UserControl
    {
        AppForm _appFormParent;
        public HomeControl(AppForm appFormParent)
        {
            _appFormParent = appFormParent;
            InitializeComponent();
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
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            try
            {
                labelServiceStatus.Text = "Trwa zatrzymywanie usługi...";
                pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
                btnStopService.Enabled = false;
                btnReStartService.Enabled = false;
                _appFormParent.StopService();
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void buttonAppRestart_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Restart();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            try
            {
                labelServiceStatus.Text = "Trwa uruchamianie usługi...";
                pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
                btnStartService.Enabled = false;
                btnReStartService.Enabled = false;
                _appFormParent.StartService();
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
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
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }
        }

        private void btnReStartService_Click(object sender, EventArgs e)
        {
            try
            {
                labelServiceStatus.Text = "Trwa restartowanie usługi...";
                pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
                btnStopService.Enabled = false;
                btnReStartService.Enabled = false;
                _appFormParent.ReStartService();
            }
            catch (Exception ex)
            {
                //ServiceConnector_MessageHandler(null, ex.ToString());
            }

        }

        #endregion

        #region privateMethods

        private void OnStopped()
        {
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.red;
            labelServiceStatus.Text = "Stan usługi: Zatrzymana";
            btnStartService.Enabled = true;
            btnStopService.Enabled = false;
        }

        private void OnRunning()
        {
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.green;
            labelServiceStatus.Text = "Stan usługi: Uruchomiona";
            btnStartService.Enabled = false;
            btnStopService.Enabled = true;
        }

        private void OnStartPending()
        {
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
            labelServiceStatus.Text = "Stan usługi: Uruchamianie...";
        }
        private void OnStopPending()
        {
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
            labelServiceStatus.Text = "Stan usługi: Zatrzymywanie...";
        }

        private void OnOtherStatus(ServiceControllerStatus result)
        {
            pictureServiceStatus.Image = CodeCompilerServiceManager.Properties.Resources.yellow;
            labelServiceStatus.Text = "Stan usługi: " + result.ToString();
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

        public void ServiceConnector_MessageHandler(object? sender, string errorMessage)
        {
            if (txtOutputConsole.InvokeRequired)
            {
                Action safeWrite = delegate { ServiceConnector_MessageHandler(null, errorMessage); };
                txtOutputConsole.Invoke(safeWrite);
            }
            else
            {
                string errMessage = DateTime.Now + " " + "[ServiceManager] - " + " " + errorMessage;
                txtOutputConsole.ForeColor = Color.Red;
                txtOutputConsole.Text += errMessage;
                txtOutputConsole.Text += Environment.NewLine;
            }
        }
        #endregion
    }
}