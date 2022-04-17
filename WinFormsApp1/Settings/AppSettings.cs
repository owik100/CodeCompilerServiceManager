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
        public static TimeSpan OperationTimeout;
        public static int CheckStatusInterval;
        public static bool RefreshStatusEnabled;
        public static string ServicePath;

        public static event EventHandler<string> GetMessage;

        public static void OnMessage(string errorMessage)
        {
            GetMessage?.Invoke(null, errorMessage);
        }

        public static AppSettingsModel RestartSettings()
        {
            AppSettingsModel model = new AppSettingsModel()
            {
                OperationTimeout = TimeSpan.FromMilliseconds(5000),
                CheckStatusInterval = 3000,
                RefreshStatusEnabled = true,
            };

            OperationTimeout = TimeSpan.FromMilliseconds(5000);
            CheckStatusInterval = 3000;
            RefreshStatusEnabled = true;

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
                key.SetValue("RefreshStatusEnabled", model.RefreshStatusEnabled);
                key.Close();
            }
            catch (Exception ex)
            {
                OnMessage(ex.ToString());
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

                    string refreshStatusEnabled = key.GetValue("RefreshStatusEnabled").ToString();
                    result.RefreshStatusEnabled = bool.Parse(refreshStatusEnabled);
                    key.Close();
                }
                else
                {
                    result = RestartSettings();
                }
            }
            catch (Exception ex)
            {
                OnMessage(ex.ToString());
                RestartSettings();
            }
            OperationTimeout = result.OperationTimeout;
            CheckStatusInterval = result.CheckStatusInterval;
            RefreshStatusEnabled = result.RefreshStatusEnabled;

            return result;
        }
    }


}
