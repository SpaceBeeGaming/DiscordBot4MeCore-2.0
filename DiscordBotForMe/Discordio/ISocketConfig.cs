using Discord.WebSocket;

namespace DiscordBotForMe.Discordio
{
    public interface ISocketConfig
    {
        DiscordSocketConfig GetDefault();
        DiscordSocketConfig GetNew();
    }
}