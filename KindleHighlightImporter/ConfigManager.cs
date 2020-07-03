using System;
using System.Configuration;

namespace KindleHighlightImporter
{
    public static class ConfigManager
    {
        public static void UpdateAttribute (string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        public static string GetAttribute (string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
