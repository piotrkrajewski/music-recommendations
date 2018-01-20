using Newtonsoft.Json;
using System.Collections.Generic;

namespace Arbetsprov.Common.SpotifyApi.ResponseModels
{
    public class GenreResponse
    {
        [JsonProperty("genres")]
        public IEnumerable<string> Genres { get; set; }
    }
}