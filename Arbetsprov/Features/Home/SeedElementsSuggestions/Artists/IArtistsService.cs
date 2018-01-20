using Arbetsprov.Common.SpotifyApi.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arbetsprov.Features.Home.SeedElementsSuggestions.Artists
{
    public interface IArtistsService
    {
        Task<IEnumerable<Artist>> GetArtists(string nameQuery);
    }
}