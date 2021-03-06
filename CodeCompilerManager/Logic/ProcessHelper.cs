using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Logic
{
    public class ProcessHelper : IProcessHelper
    {
        public string InstallServiceUsingCMD(string pathToServiceExe)
        {
            string output = "";
            if (File.Exists(pathToServiceExe + "\\CodeCompilerService.exe"))
            {
                Process p = new Process();
                p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage);
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "CMD.exe";
                p.StartInfo.Arguments = $"/C SC CREATE \"CodeCompilerServiceOwik\" binpath={pathToServiceExe + "\\CodeCompilerService.exe"}";
                p.Start();
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            else
            {
                output = "[ERROR] The service file cannot be found in the specified directory!";
            }
            return output;
        }

        public string RemoveService()
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
            return output;
        }
    }
}
