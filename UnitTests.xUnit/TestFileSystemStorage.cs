using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;

using DiscordBotForMeCore.Storage;
using DiscordBotForMeCore.Storage.Implementations;

using Newtonsoft.Json;

using Xunit;

namespace UnitTests.xUnit
{
    public class TestFileSystemStorage
    {
        [Theory]
        [InlineData("TestString", "Config/Test")]
        [InlineData(1, "Config/Test")]
        [InlineData("TestString", "Test")]
        [InlineData("", "Config/Test")]
        [InlineData(new int[] { 1, 4, 7, 0 }, "Config/Test")]
        [InlineData(new string[] { "Hello", "Test", "Blah" }, "Config/Test")]
        public void Store_ShouldStore(object obj, string key)
        {
            MockFileSystem fileSystem = new MockFileSystem();

            IDataStorage dataStorage = new JsonStorage(fileSystem);
            dataStorage.Store(obj, key);

            Assert.True(fileSystem.File.Exists(key + ".json"));
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Config/Test.json")]
        [InlineData("Test.json")]
        public void Store_InvalidKey_ShouldThrow(string key)
        {
            const string obj = "TestObject";

            MockFileSystem fileSystem = new MockFileSystem();

            IDataStorage dataStorage = new JsonStorage(fileSystem);

            Assert.Throws<ArgumentException>(() =>
            {
                dataStorage.Store(obj, key);
            });
        }

        [Fact]
        public void Store_nullObject_ShouldThrow()
        {
            const string key = "ABC";

            MockFileSystem fileSystem = new MockFileSystem();

            IDataStorage dataStorage = new JsonStorage(fileSystem);

            Assert.Throws<ArgumentNullException>(() =>
            {
                dataStorage.Store(null, key);
            });
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Restore_InvalidKey_ShouldThrow(string key)
        {
            MockFileSystem fileSystem = new MockFileSystem();

            IDataStorage dataStorage = new JsonStorage(fileSystem);
            Assert.Throws<ArgumentException>(() =>
            {
                dataStorage.RestoreObject<object>(key);
            });
        }

        [Fact]
        public void Restore_WrongKey_ShouldThrow()
        {
            const string invalidKey = "bdldkf";

            MockFileSystem fileSystem = new MockFileSystem();

            IDataStorage dataStorage = new JsonStorage(fileSystem);

            Assert.Throws<ArgumentException>(() =>
            {
                dataStorage.RestoreObject<string>(invalidKey);
            });
        }

        [Theory]
        [InlineData("TestString", "Config/Test")]
        [InlineData("TestString", "Test")]
        [InlineData("", "Config/Test")]
        [InlineData(new int[] { 1, 4, 7, 0 }, "Config/Test")]
        [InlineData(new string[] { "Hello", "Test", "Blah" }, "Config/Test")]
        public void Restore_ShouldRestore(object toRestore, string key)
        {

            MockFileSystem fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                {@"c:/"+key+".json", new MockFileData(GetComparisonElements(toRestore).jsonString)}
            });

            IDataStorage dataStorage = new JsonStorage(fileSystem);
            object restored = dataStorage.RestoreObject<object>(key);

            Assert.True(GetComparisonElements(toRestore).deserializedJsonString.ToString() == restored.ToString());
        }

        private (string jsonString, object deserializedJsonString) GetComparisonElements(object obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            object output = JsonConvert.DeserializeObject<object>(jsonString);
            return (jsonString, output);
        }
    }
}
