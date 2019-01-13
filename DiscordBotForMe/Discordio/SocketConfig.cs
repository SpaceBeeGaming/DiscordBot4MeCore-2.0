using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;

namespace DiscordBotForMe.Discordio
{
    public class SocketConfig
    {
        public DiscordSocketConfig GetDefault()
        {
            return new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            };
        }

        public DiscordSocketConfig GetNew()
        {
            return new DiscordSocketConfig();
        }
    }
}
