using System;
using System.Threading.Tasks;
using Autofac;
using DiscordBotForMeCore.Discordio;
using DiscordBotForMeCore.Discordio.Entities;
using DiscordBotForMeCore.Logging;
using DiscordBotForMeCore.Storage;
using DiscordBotForMeCore.Storage.Implementations;

namespace DiscordBotForMeCore
{
    class Program
    {
        private static async Task Main()
        {
            IContainer container = ContainerConfig.Configure();

            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                IApplication app = scope.Resolve<IApplication>();

                await app.Run();
            }
        }
    }
}
