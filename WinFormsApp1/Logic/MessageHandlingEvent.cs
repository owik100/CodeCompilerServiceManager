using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Logic
{
    public class MessageHandlingArgs : EventArgs
    {
        public MessageHandlingArgs(string message, MessageHandlingLevel level)
        {
            Message = message;
            Level = level;
        }
        public string Message { get; set; }
        public MessageHandlingLevel Level { get; set; }
    }

    public enum MessageHandlingLevel
    {
        ServiceInfo,
        ServiceError,
        ManagerInfo,
        ManagerError,
    }
}
