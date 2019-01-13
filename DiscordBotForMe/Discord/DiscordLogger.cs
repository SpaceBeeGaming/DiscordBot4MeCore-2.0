using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using DiscordBotForMe.Logging;

namespace DiscordBotForMe.Discord
{
    public class DiscordLogger
    {
        private readonly ILogger logger;

        public DiscordLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public void Log(LogMessage logMessage)
        {
            logger.Log(logMessage.Message);
        }


    }
}
