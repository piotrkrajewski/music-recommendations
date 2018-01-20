using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arbetsprov.Features.Home.SeedElementsSuggestions.Genres
{
    public interface IGenresService
    {
        Task<IEnumerable<Genre>> GetGenres(string query);
    }
}