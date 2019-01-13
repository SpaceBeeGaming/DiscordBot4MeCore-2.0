using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBotForMe.Discordio.Entities;

namespace DiscordBotForMe.Discordio
{
    class Connection
    {
        private readonly DiscordSocketClient client;
        private readonly DiscordLogger logger;

        public Connection(DiscordSocketClient client, DiscordLogger logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task ConnectAsync(DiscordBotConfig config)
        {
            client.Log += logger.Log;

            await client.LoginAsync(Discord.TokenType.Bot, config.Token);
            await client.StartAsync();

            await Task.Delay(-1);
        }
    }
}
