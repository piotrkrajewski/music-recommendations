using Newtonsoft.Json;

namespace Arbetsprov.Common.SpotifyApi.ResponseModels
{
    public class SearchArtistResponse
    {
        [JsonProperty("artists")]
        public ArtistsCollection Artists { get; set; }
    }
}