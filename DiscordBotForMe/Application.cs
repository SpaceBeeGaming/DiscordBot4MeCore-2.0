using System.Threading.Tasks;

using DiscordBotForMeCore.Discordio;
using DiscordBotForMeCore.Discordio.Entities;
using DiscordBotForMeCore.Storage;

namespace DiscordBotForMeCore
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

