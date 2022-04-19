using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using CodeCompilerServiceManager.Settings;
using System.Diagnostics;
using System.Globalization;
using System.Management;
using CodeCompilerServiceManager.Logic;

namespace CodeCompilerServiceManager.Logic
{
    public class ServiceProxy : IServiceProxy
    {
        //TODO DI?
        ServiceController _sc;
        public event EventHandler<string> GetMessage;

        public ServiceProxy()
        {
            _sc = new ServiceController("CodeCompilerServiceOwik");
        }

        protected virtual void OnMessage(string errorMessage)
        {
            GetMessage?.Invoke(this, errorMessage);
        }

        public ServiceControllerStatus RunService()
        {
            ServiceControllerStatus result = ServiceControllerStatus.Stopped;
            try
            {
                _sc.Refresh();
                if (_sc.Status != ServiceControllerStatus.Running && _sc.Status != ServiceControllerStatus.StartPending)
                {
                    _sc.Start();
                    _sc.WaitForStatus(ServiceControllerStatus.Running, AppSettings.OperationTimeout);
                    result = _sc.Status;
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.ToString());
            }
            return result;
        }

        public ServiceControllerStatus StopService()
        {
            ServiceControllerStatus result = ServiceControllerStatus.Stopped;
            try
            {
                _sc.Refresh();
                if (_sc.Status != ServiceControllerStatus.Stopped && _sc.Status != ServiceControllerStatus.StopPending)
                {
                    _sc.Stop();
                    _sc.WaitForStatus(ServiceControllerStatus.Stopped, AppSettings.OperationTimeout);
                    result = _sc.Status;
                }

            }
            catch (Exception ex)
            {
                OnMessage(ex.ToString());
            }
            return result;
        }

        public ServiceControllerStatus RestartService()
        {
            ServiceControllerStatus result = ServiceControllerStatus.Stopped;
            try
            {
                _sc.Refresh();
                if (_sc.Status != ServiceControllerStatus.StopPending || _sc.Status == ServiceControllerStatus.StartPending)
                {
                    int millisec1 = Environment.TickCount;
                    TimeSpan timeoutLocal = AppSettings.OperationTimeout;

                    if (_sc.Status != ServiceControllerStatus.Stopped)
                    {
                        _sc.Stop();
                        _sc.WaitForStatus(ServiceControllerStatus.Stopped, timeoutLocal);
                    }

                    int millisec2 = Environment.TickCount;
                    timeoutLocal = TimeSpan.FromMilliseconds(AppSettings.OperationTimeout.TotalMilliseconds - (millisec2 - millisec1));

                    _sc.Start();
                    _sc.WaitForStatus(ServiceControllerStatus.Running, timeoutLocal);
                    result = _sc.Status;
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.ToString());
            }
            return result;
        }

        public ServiceControllerStatus GetServiceStatus()
        {
            ServiceControllerStatus result = ServiceControllerStatus.Stopped;
            try
            {
                _sc.Refresh();
                result = _sc.Status;
            }
            catch (Exception ex)
            {
                OnMessage(ex.ToString());
            }
            return result;
        }

        public string GetServicePath()
        {
            string result = "";
            try
            {
                string ServiceName = "CodeCompilerServiceOwik";
                using (ManagementObject wmiService = new ManagementObject("Win32_Service.Name='CodeCompilerServiceOwik'"))
                {
                    wmiService.Get();
                    result = wmiService["PathName"].ToString();
                }

            }
            catch (Exception ex)
            {
                OnMessage(ex.ToString());
            }
            return result;
        }

        //TODO Przeniesc kody z procesow z okienkami windowsa gdzies indziej
        public string InstallService()
        {
            try
            {
                bool serviceExists = ServiceController.GetServices().Any(s => s.ServiceName == "CodeCompilerServiceOwik");
                if (serviceExists)
                {
                    OnMessage("Usługu jest już zainstalowana!");
                }
                else
                {
                    string selectedFolder = "";
                    MessageBox.Show("Wybierz folder zawierający usługę CodeCompilerServiceOwik", "Wybór ścieżki",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
                    {
                        System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            selectedFolder = dialog.SelectedPath;
                        }
                        else
                        {
                            return "";
                        }
                    }

                    Process p = new Process();
                    p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage);
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = "CMD.exe";
                    p.StartInfo.Arguments = $"/C SC CREATE \"CodeCompilerServiceOwik\" binpath={selectedFolder + "\\CodeCompilerService.exe"}";
                    p.Start();
                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    OnMessage(output);
                    return selectedFolder;
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.ToString());
            }
            return "";
        }
        public bool RemoveService()
        {
            try
            {
                bool serviceExists = ServiceController.GetServices().Any(s => s.ServiceName == "CodeCompilerServiceOwik");

                if (!serviceExists)
                {
                    OnMessage("Usługu nie jest zainstalowana!");
                }
                else
                {

                    DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz odinstalować usługę CodeCompilerServiceOwik?", "Uwaga", MessageBoxButtons.YesNo,icon: MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Process p = new Process();
                        p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage);
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.FileName = "CMD.exe";
                        p.StartInfo.Arguments = "/C SC DELETE \"CodeCompilerServiceOwik\"";
                        p.Start();
                        string output = p.StandardOutput.ReadToEnd();
                        p.WaitForExit();
                        OnMessage(output);
                        return true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.ToString());
            }
            return false;
        }
    }
}
