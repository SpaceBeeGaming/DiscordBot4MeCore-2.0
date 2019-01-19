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

        public bool KeyExists(string key)
        {
            string file = ValidPath(key);
            return fileSystem.File.Exists(file) ? true : false;
        }

        public T RestoreObject<T>(string key)
        {
            string file = ValidPath(key);
            if (!fileSystem.File.Exists(file)) throw new ArgumentException($"Key '{key}' pointing to file '{file}', doesn't exist.");
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

        private string ValidPath(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Key is null or whitespace!", nameof(key));
            if (key.Contains(".json")) throw new ArgumentException($"Key '{key}' must point to a File, without extention.");

            return $"{key}.json";
        }
    }
}
