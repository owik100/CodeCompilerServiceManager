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
        public ServiceProxy()
        {
            _sc = new ServiceController("CodeCompilerServiceOwik");
        }
        public ServiceControllerStatus RunService()
        {
            try
            {
                _sc.Refresh();
                if (_sc.Status != ServiceControllerStatus.Running && _sc.Status != ServiceControllerStatus.StartPending)
                {
                    _sc.Start();
                    _sc.WaitForStatus(ServiceControllerStatus.Running, AppSettings.OperationTimeout);
                }
            }
            catch (Exception ex)
            {
                //LogToApp
            }
            return _sc.Status;
        }

        public ServiceControllerStatus StopService()
        {
            try
            {
                _sc.Refresh();
                if (_sc.Status != ServiceControllerStatus.Stopped && _sc.Status != ServiceControllerStatus.StopPending)
                {
                    _sc.Stop();
                    _sc.WaitForStatus(ServiceControllerStatus.Stopped, AppSettings.OperationTimeout);
                }

            }
            catch (Exception ex)
            {
                //LogToApp
            }
            return _sc.Status;
        }

        public ServiceControllerStatus RestartService()
        {
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
                }
            }
            catch (Exception ex)
            {
                //LogToApp
            }
            return _sc.Status;
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
                //LogToApp
            }
            return result;
        }
    }
}
