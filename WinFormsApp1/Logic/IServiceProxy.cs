﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Logic
{
    public interface IServiceProxy : IMeesageHandling
    {
        public ServiceControllerStatus RunService();
        public ServiceControllerStatus StopService();
        public ServiceControllerStatus RestartService();
        public ServiceControllerStatus GetServiceStatus();
        public string GetServicePath();
        public string InstallService();
        public bool RemoveService();
    }
}
