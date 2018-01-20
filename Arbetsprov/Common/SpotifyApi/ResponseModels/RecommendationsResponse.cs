using Newtonsoft.Json;
using System.Collections.Generic;

namespace Arbetsprov.Common.SpotifyApi.ResponseModels
{
    public class RecommendationsResponse
    {
        [JsonProperty("tracks")]
        public IList<Track> Tracks { get; set; }
    }
}