using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Settings
{
    public static class AppSettings
    {
        //TODO Zapis i odczyt do rejestru
        public static TimeSpan OperationTimeout;
        public static int CheckStatusInterval;

        public static AppSettingsModel RestartSettings()
        {
            AppSettingsModel model = new AppSettingsModel()
            {
                OperationTimeout = TimeSpan.FromMilliseconds(5000),
                CheckStatusInterval = 3000,
            };

            OperationTimeout = TimeSpan.FromMilliseconds(5000);
            CheckStatusInterval = 3000;

            SaveSettings(model);
            return model;
        }

        public static void SaveSettings(AppSettingsModel model)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\CodeCompilerServiceManager");

                key.SetValue("OperationTimeout", model.OperationTimeout);
                key.SetValue("CheckStatusInterval", model.CheckStatusInterval);
                key.Close();
            }
            catch (Exception ex)
            {
                //log
            }
        }

        public static AppSettingsModel LoadSettings()
        {
            AppSettingsModel result = new AppSettingsModel();
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\CodeCompilerServiceManager");

                if (key != null)
                {
                    string operationTimeout = key.GetValue("OperationTimeout").ToString();
                    result.OperationTimeout = TimeSpan.Parse(operationTimeout);

                    string checkStatusInterval = key.GetValue("CheckStatusInterval").ToString();
                    result.CheckStatusInterval = Convert.ToInt32(checkStatusInterval);
                    key.Close();
                }
                else
                {
                    result = RestartSettings();
                }
            }
            catch (Exception ex)
            {
                //log
                RestartSettings();
            }
            OperationTimeout = result.OperationTimeout;
            CheckStatusInterval = result.CheckStatusInterval;

            return result;
        }
    }


}
