using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twitch;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwitchController : ControllerBase
    {
        // https://dev.twitch.tv/docs/api/webhooks-guide#subscriptions
        [HttpGet("{username}")]
        public string SubscriptionChallenge(string username, [FromQuery(Name = "hub.challenge")] string token)  
        {
            return token;
        }

        // https://dev.twitch.tv/docs/api/webhooks-reference/#topic-stream-changed
        [HttpPost("{username}")]
        public async Task<IActionResult> StreamChangeEvent(string username, [FromBody] StreamEvents events)
        {
            return Ok();
        }
    }
}