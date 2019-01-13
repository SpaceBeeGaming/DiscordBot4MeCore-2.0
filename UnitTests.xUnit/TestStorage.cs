using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DiscordBotForMeCore.Storage;
using DiscordBotForMeCore.Storage.Implementations;
using Newtonsoft.Json;
using Xunit;

namespace UnitTests.xUnit
{
    public class TestStorage
    {
        [Theory]
        [InlineData("TestString", "Config/Test")]
        [InlineData("TestString", "Test")]
        [InlineData("", "Config/Test")]
        [InlineData(null, "Config/Test")]
        [InlineData(new int[] { 1, 4, 7, 0 }, "Config/Test")]
        [InlineData(new string[] { "Hello", "Test", "Blah" }, "Config/Test")]
        public void Store_ShouldStore(object obj, string key)
        {
            IDataStorage dataStorage = new JsonStorage();
            dataStorage.Store(obj, key);

            if (Directory.Exists("Config"))
            {
                Directory.Delete("Config", true);
            }
            else if (File.Exists("Test.json"))
            {
                File.Delete("Test.json");
            }
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Store_ShouldThrow(string key)
        {
            IDataStorage dataStorage = new JsonStorage();

            Exception ex = Record.Exception(() =>
            {
                dataStorage.Store(null, key);
            });

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }


        [Theory]
        [InlineData("TestString", "Config/Test")]
        [InlineData("TestString", "Test")]
        [InlineData("", "Config/Test")]
        [InlineData(null, "Config/Test")]
        [InlineData(new int[] { 1, 4, 7, 0 }, "Config/Test")]
        [InlineData(new string[] { "Hello", "Test", "Blah" }, "Config/Test")]
        public void Restore_ShouldRestore(object obj, string key)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Directory.CreateDirectory("Config");
            File.WriteAllText("Config/Test.json", json);
            File.WriteAllText("Test.json", json);

            IDataStorage dataStorage = new JsonStorage();
            object restored = dataStorage.RestoreObject<object>(key);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Restore_ShouldThrow(string key)
        {
            string json = JsonConvert.SerializeObject(null, Formatting.Indented);
            File.WriteAllText("Test.json", json);

            IDataStorage dataStorage = new JsonStorage();
            Exception ex = Record.Exception(() =>
            {
                dataStorage.RestoreObject<object>(key);
            });

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }
    }
}
