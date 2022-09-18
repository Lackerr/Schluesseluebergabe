using Newtonsoft.Json;
using System;
using System.IO;

namespace Schluesseluebergabe.Stores
{
    class ConfigManager : IConfigManager
    {
        private readonly string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Schluesseluebergabe");
        private readonly string _fileName = "config.json";
        private readonly string _filePath;
        private Config _config;

        private static ConfigManager _instance;


        public static ConfigManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;


                return _instance = new ConfigManager();
            }
            set
            {
                _instance = value;
            }
        }

        private ConfigManager()
        {
            _filePath = Path.Combine(_path, _fileName);
            _config = LoadConfig();
        }

        public Config GetConfig()
        {
            return _config;
        }


        public  void SaveConfig(Config config)
        {
            _config = config;
            var json = JsonConvert.SerializeObject(config);

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            using (StreamWriter writer = new(_filePath))
            {
                writer.Write(json);
            };

        }

        private Config? LoadConfig()
        {
            Config config;
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            if (!File.Exists(_filePath))
            {
                config = new Config();
                SaveConfig(config);
                return config;
            }


            StreamReader reader = new(_filePath);
            var result = reader.ReadToEnd();
            config = JsonConvert.DeserializeObject<Config>(result);

            return config;
        }
    }
}
