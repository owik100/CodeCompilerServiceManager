using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using CodeCompilerServiceManager.Settings;

namespace CodeCompilerServiceConfig.Logic
{
    public class ServiceProxy
    {
        //TODO DI?
        ServiceController _sc;
        public event EventHandler<string> ErrorMessage;

        public ServiceProxy()
        {
            _sc = new ServiceController("CodeCompilerServiceOwik");
        }

        protected virtual void OnErrorMessage(string errorMessage)
        {
            ErrorMessage?.Invoke(this, errorMessage);
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
                OnErrorMessage(ex.Message);
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
                OnErrorMessage(ex.Message);
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

                    if (_sc.Status != ServiceControllerStatus.Stopped) {
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
                OnErrorMessage(ex.Message);
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
                OnErrorMessage(ex.Message);
            }
            return result;
        }
    }
}
