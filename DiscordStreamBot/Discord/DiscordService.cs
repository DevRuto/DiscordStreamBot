using System.Reflection;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DiscordStreamBot.Discord
{
    public class DiscordService : IDiscordService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;
        private readonly DiscordClient _discordClient;

        public DiscordService(IConfiguration config, ILogger<DiscordService> logger)
        {
            _logger = logger;
            _config = config;
            _discordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = config["Discord:Token"],
                TokenType = TokenType.Bot
            });
        }

        public async Task StartBot()
        {
            _logger.LogInformation("Discord | Starting Discord Bot");

            await _discordClient.ConnectAsync();

            var commands = _discordClient.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = new[] { _config["Discord:Prefix"] }
            });
            commands.RegisterCommands(Assembly.GetExecutingAssembly());

            foreach (var command in commands.RegisteredCommands)
            {
                _logger.LogInformation("Discord | Commands | Registed Command {command}", command.Key);
            }
        }
    }
}