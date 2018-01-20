using Newtonsoft.Json;
using System.Collections.Generic;

namespace Arbetsprov.Common.SpotifyApi.ResponseModels
{
    public class Track
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("artists")]
        public IList<Artist> Artists { get; set; }

        [JsonProperty("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }
    }
}