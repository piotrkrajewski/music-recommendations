using Arbetsprov.Common.SpotifyApi.ResponseModels;
using Flurl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Arbetsprov.Common.SpotifyApi
{
    public class SpotifyService : ISpotifyService
    {
        private const string BaseUrl = "https://api.spotify.com/";
        private const string ClientIdConfigKey = "SpotifyClientId";
        private const string ClientSecretConfigKey = "SpotifyClientSecret";

        private readonly string _clientId;
        private readonly string _clientSecret;

        public SpotifyService()
        {
            _clientId = WebConfigurationManager.AppSettings[ClientIdConfigKey];
            _clientSecret = WebConfigurationManager.AppSettings[ClientSecretConfigKey];
        }

        public async Task<SearchArtistResponse> SearchArtistsAsync(string query)
        {
            HttpClient client = GetHttpClient();

            var url = new Url("/v1/search");
            url = url.SetQueryParam("q", query);
            url = url.SetQueryParam("type", "artist");

            string response = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<SearchArtistResponse>(response);
        }

        public async Task<GenreResponse> GetGenresAsync()
        {
            HttpClient client = GetHttpClient();

            var url = new Url("/v1/recommendations/available-genre-seeds");

            string response = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<GenreResponse>(response);
        }

        public async Task<RecommendationsResponse> GetRecommendationsAsync(IEnumerable<string> artistsIds, IEnumerable<string> genresIds, int energyPercent)
        {
            HttpClient client = GetHttpClient();

            string artistsIdsString = string.Join(",", artistsIds);
            string genresIdsString = string.Join(",", genresIds);
            string energyString = Math.Round(energyPercent / (float)100, 1)
                .ToString(CultureInfo.InvariantCulture);

            var url = new Url("/v1/recommendations");
            url = url.SetQueryParam("seed_artists", artistsIdsString);
            url = url.SetQueryParam("seed_genres", genresIdsString);
            url = url.SetQueryParam("target_energy", energyString);

            string response = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<RecommendationsResponse>(response);
        }

        private HttpClient GetHttpClient()
        {
            var authHandler = new SpotifyAuthClientCredentialsHttpMessageHandler(
                _clientId,
                _clientSecret,
                new HttpClientHandler());

            var client = new HttpClient(authHandler)
            {
                BaseAddress = new Uri(BaseUrl)
            };

            return client;
        }
    }
}