using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Arbetsprov.Features.Home.SeedElementsSuggestions
{
    [RoutePrefix("seed-elements-suggestions")]
    public class SeedElementsSuggestionsController : Controller
    {
        public const string ApplicationJson = "application/json";

        private readonly ISeedElementsSuggestionsService _seedElementsSuggestionsService;

        public SeedElementsSuggestionsController(ISeedElementsSuggestionsService seedElementsSuggestionsService)
        {
            _seedElementsSuggestionsService = seedElementsSuggestionsService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ContentResult> GetSeedElementsSuggestionAsync(string query)
        {
            IEnumerable<SeedElementsSuggestionsGroup> seedElementsSuggestionsGroups = await _seedElementsSuggestionsService.GetSeedElementsSuggestionsAsync(query);
            string jsonString = JsonConvert.SerializeObject(seedElementsSuggestionsGroups);

            return Content(jsonString, ApplicationJson);
        }
    }
}