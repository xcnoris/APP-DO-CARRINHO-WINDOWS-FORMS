using Newtonsoft.Json;
using System.IO;

namespace banco.DAL.DataBases
{
    public static class ControlConfig
    {
        private const string DirArquivo = "dbconfig.json";

        public static DBConfig LoadConfig()
        {
            if (File.Exists(DirArquivo))
            {
                string json = File.ReadAllText(DirArquivo);
                return JsonConvert.DeserializeObject<DBConfig>(json);
            }
            return null;
        }

        public static void SalvarConfig(DBConfig config)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(DirArquivo, json);
        }
    }
}
