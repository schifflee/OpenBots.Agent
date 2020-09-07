using Newtonsoft.Json;
using System;
using System.IO;

namespace OpenBots.Agent.Client
{
    public static class SettingsManager
    {
        public static void UpdateSettings(OpenBotsSettings agentSettings)
        {
            File.WriteAllText(GetSettingsFilePath(), JsonConvert.SerializeObject(agentSettings, Formatting.Indented));
        }

        public static OpenBotsSettings ReadSettings()
        {
            return JsonConvert.DeserializeObject<OpenBotsSettings>(File.ReadAllText(GetSettingsFilePath()));
        }

        public static string GetSettingsFilePath()
        {
            string settingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"OpenBots.settings");
            if (!File.Exists(settingsFilePath))
                throw new FileNotFoundException($"File NOT found at {settingsFilePath}");
            return settingsFilePath;
        }
    }
}
