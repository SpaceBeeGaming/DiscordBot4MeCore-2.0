using Autofac;
using Autofac.Core;
using Discord.WebSocket;
using DiscordBotForMe.Discordio;
using DiscordBotForMe.Discordio.Entities;
using DiscordBotForMe.Logging;
using DiscordBotForMe.Storage;
using DiscordBotForMe.Storage.Implementations;

namespace DiscordBotForMe
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<DiscordBotConfig>().As<IDiscordBotConfig>().SingleInstance();
            builder.RegisterType<SocketConfig>().As<ISocketConfig>().SingleInstance();

            ///DiscordSocletClient
            builder.Register(ctx =>
            {
                DiscordSocketConfig config = ctx.Resolve<ISocketConfig>().GetDefault();
                return new DiscordSocketClient(config);
            }).SingleInstance();

            builder.RegisterType<DiscordLogger>().SingleInstance();

            builder.RegisterType<JsonStorage>().As<IDataStorage>().SingleInstance();
            builder.RegisterType<ConsoleLogger>().As<ILogger>().SingleInstance();

            builder.RegisterType<Connection>().As<IConnection>().SingleInstance();
            builder.RegisterType<Application>().As<IApplication>();

            return builder.Build();
        }
    }
}
