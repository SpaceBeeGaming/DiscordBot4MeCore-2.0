using System;
using System.Collections.Generic;
using System.Text;
using DiscordBotForMe.Logging;
using Xunit;

namespace UnitTests.xUnit
{
    public class TestLogging
    {
        [Theory]
        [InlineData("Testing")]
        [InlineData("")]
        [InlineData(null)]
        public void Log_ShouldLog(string message)
        {
            ILogger logger = new ConsoleLogger();
            logger.Log(message);
        }
    }
}
