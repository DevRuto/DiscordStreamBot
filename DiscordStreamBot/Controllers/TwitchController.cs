using System.Threading.Tasks;
using DiscordStreamBot.Twitch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiscordStreamBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwitchController : ControllerBase
    {
        private readonly ILogger _logger;

        public TwitchController(ILogger<TwitchController> logger)
        {
            _logger = logger;
        }

        // https://dev.twitch.tv/docs/api/webhooks-guide#subscriptions
        [HttpGet("{username}")]
        public string SubscriptionChallenge(string username, [FromQuery(Name = "hub.challenge")] string token)  
        {
            _logger.LogInformation("API | Twitch | Challenge Received for '{username}'", username);
            return token;
        }

        // https://dev.twitch.tv/docs/api/webhooks-reference/#topic-stream-changed
        [HttpPost("{username}")]
        public async Task<IActionResult> StreamChangeEvent(string username, [FromBody] StreamEvents events)
        {
            _logger.LogInformation("API | Twitch | Stream Change Event for '{username}'", username);
            return Ok();
        }
    }
}