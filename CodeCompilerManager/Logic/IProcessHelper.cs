using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Logic
{
    public interface IProcessHelper
    {
        public string InstallServiceUsingCMD(string pathToServiceExe);
        public string RemoveService();
    }
}
