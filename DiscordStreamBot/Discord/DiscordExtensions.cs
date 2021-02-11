using Microsoft.Extensions.DependencyInjection;

namespace DiscordStreamBot.Discord
{
    public static class DiscordExtensions
    {
        public static void AddDiscord(this IServiceCollection services)
        {
            services.AddSingleton<IDiscordService, DiscordService>();
            services.AddTransient<EmbedService>();
        }
    }
}