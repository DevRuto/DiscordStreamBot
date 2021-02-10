using System.Text.Json;
using Humanizer;

namespace DiscordStreamBot.Serialization
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.Underscore();
        }        
    }

}