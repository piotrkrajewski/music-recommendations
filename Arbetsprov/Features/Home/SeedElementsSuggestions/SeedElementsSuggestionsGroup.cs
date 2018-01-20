using Newtonsoft.Json;
using System.Collections.Generic;

namespace Arbetsprov.Features.Home.SeedElementsSuggestions
{
    public class SeedElementsSuggestionsGroup
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("children")]
        public IEnumerable<SeedElementsSuggestion> Children { get; set; }
    }
}