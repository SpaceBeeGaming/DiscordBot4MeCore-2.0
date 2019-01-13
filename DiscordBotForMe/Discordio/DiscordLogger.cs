using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using DiscordBotForMeCore.Logging;

namespace DiscordBotForMeCore.Discordio
{
    public class DiscordLogger
    {
        private readonly ILogger logger;

        public DiscordLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public Task Log(LogMessage logMessage)
        {
            logger.Log(logMessage.Message);
            return Task.CompletedTask;
        }


    }
}
