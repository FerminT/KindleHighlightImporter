using System;
using System.Configuration;
using System.Windows.Forms;

namespace KindleHighlightImporter
{
    public static class ConfigManager
    {
        public static void UpdateAttribute (string key, string value)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar actualizar las configuraciones: " + ex.Message);
            }
        }

        public static string GetAttribute (string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
