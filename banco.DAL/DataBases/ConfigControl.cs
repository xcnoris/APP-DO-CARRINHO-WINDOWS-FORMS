using Newtonsoft.Json;
using System.IO;

namespace banco.DAL.DataBases
{
    public static class ConfigControl
    {
        private const string ConfigFilePath = "dbconfig.json";

        public static BDConfig LoadConfig()
        {
            if (File.Exists(ConfigFilePath))
            {
                string json = File.ReadAllText(ConfigFilePath);
                return JsonConvert.DeserializeObject<BDConfig>(json);
            }
            return null;
        }

        public static void SalvarConfig(BDConfig config)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
        }
    }
}