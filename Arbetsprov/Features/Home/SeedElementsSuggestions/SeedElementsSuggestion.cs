using Newtonsoft.Json;

namespace Arbetsprov.Features.Home.SeedElementsSuggestions
{
    public class SeedElementsSuggestion
    {
        public const char IdGroupValueSeparator = ':';
        public const string ArtistsGroupId = "artist";
        public const string GenreGroupId = "genre";

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }
}