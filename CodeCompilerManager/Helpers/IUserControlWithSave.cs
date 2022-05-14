using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Helpers
{
    public interface IUserControlWithSave
    {
        public void SaveChangesOnLeave();
        public string ControlName { get;}
    }
}
