using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arbetsprov.Features.Home.SeedElementsSuggestions
{
    public interface ISeedElementsSuggestionsService
    {
        Task<IEnumerable<SeedElementsSuggestionsGroup>> GetSeedElementsSuggestionsAsync(string query);
    }
}