using CodeCompilerServiceManager.Settings.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public ServiceSettings(string serviceConfigPath, bool restartToDefault)
        {
            ServiceSettingsModel = new ServiceSettingsModel();
            try
            {
                string jsonFileName = restartToDefault ? @"\appsettingsDefault.json" : @"\appsettings.json";
                string pathToJson = Path.GetDirectoryName(serviceConfigPath) + jsonFileName;
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

        public void SaveSettingsToJson(string serviceConfigPath)
        {
            string pathToJson = Path.GetDirectoryName(serviceConfigPath) + @"\appsettings.json";
            var jsonModel = Newtonsoft.Json.JsonConvert.SerializeObject(ServiceSettingsModel);
            JObject json = JObject.Parse(jsonModel);
            foreach (var item in json)
            {
                if (item.Key == "Serilog")
                {
                    var writeTo = item.Value["WriteTo"];
                    if (writeTo != null)
                    {
                        foreach (JToken option in writeTo)
                        {
                            var name = option.Value<string?>("Name") ?? "";
                            if (name == "EventLog" || name == "EventLogOFF")
                            {
                                var args = option["Args"];
                                if(args != null)
                                {
                                    if(args["path"] != null && args["path"].Parent != null)
                                        args["path"].Parent.Remove();
                                }
                            }

                            if (name == "Console")
                            {
                                var args = option["Args"];
                                if (args != null)
                                {
                                    if (args["source"] != null && args["source"].Parent != null)
                                        args["source"].Parent.Remove();

                                    if (args["restrictedToMinimumLevel"] != null && args["restrictedToMinimumLevel"].Parent != null)
                                        args["restrictedToMinimumLevel"].Parent.Remove();

                                    if (args["manageEventSource"] != null && args["manageEventSource"].Parent != null)
                                        args["manageEventSource"].Parent.Remove();

                                    if (args["path"] != null && args["path"].Parent != null)
                                        args["path"].Parent.Remove();
                                }
                            }

                            if (name == "File")
                            {
                                var args = option["Args"];
                                if (args != null)
                                {
                                    if (args["source"] != null && args["source"].Parent != null)
                                        args["source"].Parent.Remove();

                                    if (args["restrictedToMinimumLevel"] != null && args["restrictedToMinimumLevel"].Parent != null)
                                        args["restrictedToMinimumLevel"].Parent.Remove();

                                    if (args["manageEventSource"] != null && args["manageEventSource"].Parent != null)
                                        args["manageEventSource"].Parent.Remove();
                                }

                            }
                        }
                    }
                }
            }
            string prettyParesJson = json.ToString();

            using (StreamWriter file = File.CreateText(pathToJson))
            {
                file.Write(prettyParesJson);
            }
        }

    }
}
