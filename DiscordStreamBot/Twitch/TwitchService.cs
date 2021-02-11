using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DiscordStreamBot.Twitch
{
    public class TwitchService : ITwitchService
    {
        private static string KEY_OAUTH_TOKEN = "twitch_oauth";

        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;
        private readonly HttpClient _http;
        private readonly ILogger _logger;

        public TwitchService(IMemoryCache cache, IConfiguration config, HttpClient httpClient, ILogger<TwitchService> logger)
        {
            _cache = cache;
            _config = config;
            _http = httpClient;
            _logger = logger;

            _http.DefaultRequestHeaders.Add("Client-ID", _config["Twitch:ClientID"]);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetAuthToken().ConfigureAwait(false).GetAwaiter().GetResult());
        }

        private Task<string> GetAuthToken()
        {
            return _cache.GetOrCreateAsync<string>(KEY_OAUTH_TOKEN, async (entry) =>
            {
                using var client = new HttpClient();
                var uriBuilder = new UriBuilder("https://id.twitch.tv/oauth2/token");
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["client_id"] = _config["Twitch:ClientID"];
                query["client_secret"] = _config["Twitch:ClientSecret"];
                query["grant_type"] = "client_credentials";
                uriBuilder.Query = query.ToString();
                var response = await client.PostAsync(uriBuilder.ToString(), new StringContent(""));
                var content = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(content);
                var accessToken = doc.RootElement.GetProperty("access_token").GetString();
                var expires = doc.RootElement.GetProperty("expires_in").GetInt32();
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(expires - 100);
                _logger.LogInformation("Twitch | Cached OAuth token");
                return accessToken;
            });
        }

        public async Task<string> GetGameName(string gameId)
        {
            var requestUri = new UriBuilder(_http.BaseAddress);
            requestUri.Path = "/helix/games";

            var query = HttpUtility.ParseQueryString(requestUri.Query);
            query["id"] = gameId;
            requestUri.Query = query.ToString();

            var response = await _http.GetStringAsync(requestUri.Uri);
            using var doc = JsonDocument.Parse(response);

            var enumerator = doc.RootElement.GetProperty("data").EnumerateArray();
            if (!enumerator.MoveNext())
                return null;

            return enumerator.Current.GetProperty("name").GetString();
        }
    }
}