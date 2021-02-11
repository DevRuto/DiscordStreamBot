using System.Threading.Tasks;

namespace DiscordStreamBot.Twitch
{
    public interface ITwitchService
    {
        Task<string> GetGameName(string id);
    }
}