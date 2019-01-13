using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBotForMeCore.Discordio.Entities;

namespace DiscordBotForMeCore.Discordio
{
    public class Connection : IConnection
    {
        private readonly DiscordSocketClient client;
        private readonly DiscordLogger logger;

        public Connection(DiscordSocketClient client, DiscordLogger logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task ConnectAsync(IDiscordBotConfig config)
        {
            client.Log += logger.Log;

            await client.LoginAsync(Discord.TokenType.Bot, config.Token);
            await client.StartAsync();

            await Task.Delay(-1);
        }
    }
}
