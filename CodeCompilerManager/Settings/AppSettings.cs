using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCompilerServiceManager.Settings.Models;
using CodeCompilerServiceManager.Logic;
using MaterialSkin.Controls;

namespace CodeCompilerServiceManager.Settings
{
    public static class AppSettings
    {
        public static TimeSpan OperationTimeout;
        public static int CheckStatusInterval;
        public static bool RefreshStatusEnabled;
        public static string ServicePath;

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

                OperationTimeout = model.OperationTimeout;
                CheckStatusInterval = model.CheckStatusInterval;
                RefreshStatusEnabled = model.RefreshStatusEnabled;
            }
            catch (Exception ex)
            {
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
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
                OnMessage(ex.Message , MessageHandlingLevel.ManagerError);
                RestartSettings();
            }
            OperationTimeout = result.OperationTimeout;
            CheckStatusInterval = result.CheckStatusInterval;
            RefreshStatusEnabled = result.RefreshStatusEnabled;

            return result;
        }
        #region IMeesageHandling

        public static event EventHandler<MessageHandlingArgs> GetMessage;
        public static void OnMessage(string message, MessageHandlingLevel level)
        {
            GetMessage?.Invoke(null, new MessageHandlingArgs(message, level));
        }
        #endregion
    }


}
