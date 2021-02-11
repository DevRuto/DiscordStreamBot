using Microsoft.Extensions.DependencyInjection;

namespace DiscordStreamBot.Twitch
{
    public static class TwitchExtensions
    {
        public static void AddTwitch(this IServiceCollection services)
        {
            services.AddTransient<ITwitchService, TwitchService>();
        }        
    }
}