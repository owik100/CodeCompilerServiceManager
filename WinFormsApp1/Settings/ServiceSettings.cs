using CodeCompilerServiceManager.Settings.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Settings
{
    public class ServiceSettings
    {
       public ServiceSettingsModel ServiceSettingsModel;
        public ServiceSettings(string serviceConfigPath)
        {
            ServiceSettingsModel = new ServiceSettingsModel();
            try
            {
                string pathToJson = Path.GetDirectoryName(serviceConfigPath) + @"\appsettings.json";
                using (StreamReader r = new StreamReader(pathToJson))
                {
                    string json = r.ReadToEnd();
                    ServiceSettingsModel = JsonConvert.DeserializeObject<ServiceSettingsModel>(json);
                }
            }
            catch (Exception ex)
            {
                //Log
            }
        }
        
    }
}
