using System;
using System.Threading.Tasks;
using Autofac;
using DiscordBotForMe.Discordio;
using DiscordBotForMe.Discordio.Entities;
using DiscordBotForMe.Logging;
using DiscordBotForMe.Storage;
using DiscordBotForMe.Storage.Implementations;

namespace DiscordBotForMe
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
