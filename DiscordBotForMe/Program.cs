using System;
using System.Threading.Tasks;
using DiscordBotForMe.Discordio;
using DiscordBotForMe.Discordio.Entities;
using DiscordBotForMe.Logging;
using DiscordBotForMe.Storage;
using DiscordBotForMe.Storage.Implementations;

namespace DiscordBotForMe
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            Connection connection = new Connection(new Discord.WebSocket.DiscordSocketClient(), new DiscordLogger(new ConsoleLogger()));

            IDataStorage dataStorage = new JsonStorage();
            await connection.ConnectAsync(new DiscordBotConfig
            {
                Token = dataStorage.RestoreObject<string>("Config/BotToken")
            });
        }
    }
}
