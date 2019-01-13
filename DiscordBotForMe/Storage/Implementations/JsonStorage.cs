using System.IO;

using Newtonsoft.Json;

namespace DiscordBotForMeCore.Storage.Implementations
{
    public class JsonStorage : IDataStorage
    {
        public T RestoreObject<T>(string key)
        {
            string file = ValidPath(key);
            string json = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Store(object obj, string key)
        {
            string file = ValidPath(key);
            string directory = Path.GetDirectoryName(key);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);

            }
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(file, json);
        }

        private string ValidPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) throw new System.ArgumentException("Path is null or whitespace!", nameof(path));
            return $"{path}.json";
        }
    }
}
