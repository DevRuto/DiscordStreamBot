using System;
using System.Threading.Tasks;
using DiscordStreamBot.Twitch;
using DSharpPlus.Entities;

namespace DiscordStreamBot.Discord
{
    public class EmbedService
    {
        private readonly ITwitchService _twitch;

        public EmbedService(ITwitchService twitch)
        {
            _twitch = twitch;
        }

        public async Task<DiscordEmbed> CreateStreamEmbed(StreamEvent streamEvent)
            => new DiscordEmbedBuilder()
                .WithTitle($"{streamEvent.UserName} went live")
                .AddField("Title", streamEvent.Title, false)
                .AddField("Date", streamEvent.StartedAt.ToLongDateString(), true)
                .AddField("Game", await _twitch.GetGameName(streamEvent.GameId), true)
                .WithColor(DiscordColor.Red)
                .WithUrl($"https://twitch.tv/{streamEvent.UserName}")
                .WithImageUrl(streamEvent.ThumbnailUrl.Replace("{width}", "1280").Replace("{height}", "720"))
                .WithTimestamp(DateTime.Now)
                .Build();
    }
}