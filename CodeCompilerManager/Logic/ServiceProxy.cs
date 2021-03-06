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

namespace CodeCompilerServiceManager.Logic
{
    public class ServiceProxy : IServiceProxy
    {
        ServiceController _sc;
        IProcessHelper _processHelper;

        public ServiceProxy()
        {
            _sc = new ServiceController("CodeCompilerServiceOwik");
            _processHelper = new ProcessHelper();
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
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
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
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
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
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
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
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
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
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
            }
            return result;
        }

        public bool ServiceExist()
        {
            return ServiceController.GetServices().Any(s => s.ServiceName == "CodeCompilerServiceOwik");
        }

        public bool InstallService(string pathToServiceExe)
        {
            bool result = false;
            try
            {
                string output = _processHelper.InstallServiceUsingCMD(pathToServiceExe);
                if (output.Contains("SUCCESS"))
                {
                    result = true;
                    OnMessage(output, MessageHandlingLevel.ManagerInfo);
                }
                else
                {
                    OnMessage(output, MessageHandlingLevel.ManagerError);
                }

            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
            }
            return result;
        }
        public bool RemoveService()
        {
            try
            {
                string output = _processHelper.RemoveService();
                OnMessage(output, MessageHandlingLevel.ManagerInfo);
                return true;
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
            }
            return false;
        }
        #region IMeesageHandling

        public event EventHandler<MessageHandlingArgs> GetMessage;
        protected virtual void OnMessage(string message, MessageHandlingLevel level)
        {
            GetMessage?.Invoke(this, new MessageHandlingArgs(message, level));
        }
        #endregion
    }
}
