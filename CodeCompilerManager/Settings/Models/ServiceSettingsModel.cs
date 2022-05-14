using CodeCompilerSettingsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Settings.Models
{
    public class ServiceSettingsModel
    {
        public WorkerServiceOptions ServiceOptions { get; set; }
        public CodeCompilerLibOptions CodeCompilerLibOptions { get; set; }
        public SerilogOptions Serilog { get; set; }
    }
}
