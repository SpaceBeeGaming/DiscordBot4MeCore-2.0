using System.IO;

using Newtonsoft.Json;

namespace DiscordBotForMe.Storage.Implementations
{
    public class JsonStorage : IDataStorage
    {
        public T RestoreObject<T>(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new System.ArgumentException("Path is null or whitespace!", nameof(path));
            string file = $"{path}.json";
            string json = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Store(object obj, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new System.ArgumentException("Path is null or whitespace!", nameof(path));
            string file = $"{path}.json";
            Directory.CreateDirectory(Path.GetDirectoryName(file));
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(file, json);
        }
    }
}
