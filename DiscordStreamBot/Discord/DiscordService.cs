using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DiscordStreamBot.Discord
{
    public class DiscordService : IDiscordService
    {
        private readonly ILogger _logger;

        public DiscordService(ILogger<DiscordService> logger)
        {
            _logger = logger;
        }

        public Task StartBot()
        {
            _logger.LogInformation("Discord | Starting Discord Bot");
            return Task.CompletedTask;
        }
    }
}