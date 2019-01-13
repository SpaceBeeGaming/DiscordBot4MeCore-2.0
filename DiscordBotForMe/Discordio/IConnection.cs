using System.Threading.Tasks;
using DiscordBotForMe.Discordio.Entities;

namespace DiscordBotForMe.Discordio
{
    public interface IConnection
    {
        Task ConnectAsync(IDiscordBotConfig config);
    }
}