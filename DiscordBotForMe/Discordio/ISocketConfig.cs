using Discord.WebSocket;

namespace DiscordBotForMeCore.Discordio
{
    public interface ISocketConfig
    {
        DiscordSocketConfig GetDefault();
        DiscordSocketConfig GetNew();
    }
}