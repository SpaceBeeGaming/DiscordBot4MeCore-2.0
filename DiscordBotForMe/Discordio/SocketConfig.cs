using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;

namespace DiscordBotForMeCore.Discordio
{
    public class SocketConfig : ISocketConfig
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
