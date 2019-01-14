using System;
using System.IO.Abstractions;

using Newtonsoft.Json;

namespace DiscordBotForMeCore.Storage.Implementations
{
    public class JsonStorage : IDataStorage
    {
        private readonly IFileSystem fileSystem;

        public JsonStorage() => fileSystem = new FileSystem();

        public JsonStorage(IFileSystem fileSystem) => this.fileSystem = fileSystem;

        public T RestoreObject<T>(string key)
        {
            string file = ValidPath(key);
            if (!fileSystem.File.Exists(file)) throw new ArgumentException("Key must point to a File, without extention.");
            string json = fileSystem.File.ReadAllText(file);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Store(object obj, string key)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            string file = ValidPath(key);
            string directory = fileSystem.Path.GetDirectoryName(key);
            bool debugBool = !string.IsNullOrWhiteSpace(directory);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                fileSystem.Directory.CreateDirectory(directory);
            }
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            fileSystem.File.WriteAllText(file, json);
        }

        private string ValidPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("Path is null or whitespace!", nameof(path));
            if (path.Contains(".json")) throw new ArgumentException("Key must point to a File, without extention.");

            return $"{path}.json";
        }
    }
}
