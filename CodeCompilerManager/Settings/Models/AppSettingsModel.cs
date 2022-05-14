using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Settings.Models
{
    public class AppSettingsModel
    {
        public TimeSpan OperationTimeout { get; set; }
        public int CheckStatusInterval { get; set; }
        public bool RefreshStatusEnabled { get; set; }
    }
}
