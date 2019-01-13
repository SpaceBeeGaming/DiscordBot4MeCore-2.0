using System.Threading.Tasks;

using DiscordBotForMe.Discordio;
using DiscordBotForMe.Discordio.Entities;
using DiscordBotForMe.Storage;

namespace DiscordBotForMe
{
    public class Application : IApplication
    {
        private readonly IConnection connection;

        private readonly IDataStorage dataStorage;

        private readonly IDiscordBotConfig config;

        public Application(IConnection connection, IDataStorage dataStorage, IDiscordBotConfig config)
        {
            this.connection = connection;
            this.dataStorage = dataStorage;
            this.config = config;
            config.Token = dataStorage.RestoreObject<string>("Config/BotToken");
        }

        public async Task Run()
        {
            await connection.ConnectAsync(config);
        }
    }
}

