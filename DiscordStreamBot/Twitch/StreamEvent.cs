namespace DiscordStreamBot.Twitch
{
    public record StreamEvents(StreamEvent[] Data);

    public record StreamEvent(
        string Id,
        string UserId,
        string GameId,
        long[] CommunityIds,
        string Type,
        string Title,
        int ViewerCount,
        System.DateTime StartedAt,
        string Language,
        string ThumbnailUrl
    );
}