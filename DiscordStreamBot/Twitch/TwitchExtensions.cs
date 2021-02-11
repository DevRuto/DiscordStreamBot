using Microsoft.Extensions.DependencyInjection;

namespace DiscordStreamBot.Twitch
{
    public static class TwitchExtensions
    {
        public static void AddTwitch(this IServiceCollection services)
        {
            services.AddTransient<ITwitchService, TwitchService>();
            services.AddHttpClient<ITwitchService, TwitchService>(client =>
            {
                client.BaseAddress = new System.Uri("https://api.twitch.tv");
            });
        }        
    }
}