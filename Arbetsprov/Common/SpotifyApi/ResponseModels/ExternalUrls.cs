using Newtonsoft.Json;

namespace Arbetsprov.Common.SpotifyApi.ResponseModels
{
    public class ExternalUrls
    {
        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }
}