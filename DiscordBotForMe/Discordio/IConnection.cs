using System.Threading.Tasks;
using DiscordBotForMeCore.Discordio.Entities;

namespace DiscordBotForMeCore.Discordio
{
    public interface IConnection
    {
        Task ConnectAsync(IDiscordBotConfig config);
    }
}