using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DiscordBotForMe.Storage;
using DiscordBotForMe.Storage.Implementations;
using Xunit;

namespace UnitTests.xUnit
{
    public class TestStorage
    {
        [Theory]
        [InlineData("TestString", "Config/Test")]
        [InlineData("", "Config/Test")]
        [InlineData(null, "Config/Test")]
        [InlineData("TestString", "Test")]
        public void Storage_ShouldStore(object obj, string path)
        {
            IDataStorage dataStorage = new JsonStorage();
            dataStorage.Store(obj, path);
        }


        [Theory]
        [InlineData("TestString", "")]
        [InlineData("TestString", null)]
        public void Storage_ShouldThrow(object obj, string path)
        {
            IDataStorage dataStorage = new JsonStorage();

            Exception ex = Record.Exception(() =>
            {
                dataStorage.Store(obj, path);
            });

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }
    }
}
