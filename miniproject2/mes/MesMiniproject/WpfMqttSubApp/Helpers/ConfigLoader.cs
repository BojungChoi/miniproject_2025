using System.IO;
using System.Text.Json;
using WpfMqttSubApp.Models;

namespace WpfMqttSubApp.Helpers
{
    public static class ConfigLoader
    {
        public static TotalConfig Load(string path= "config.json")
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"설정파일이 없습니다.", path);
            }

            string json = File.ReadAllText(path); // 문자열로 읽음
            var config = JsonSerializer.Deserialize<TotalConfig>(json);
            
            if (config == null)
            {
                throw new InvalidDataException("설정파일이 올바르지 않습니다.");
            }
            return config;
        }
    }
}
