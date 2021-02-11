using System.Threading.Tasks;

namespace DiscordStreamBot.Twitch
{
    public class TwitchService : ITwitchService
    {
        public Task<string> GetGameName(string id)
        {
            return Task.FromResult("");
        }
    }
}