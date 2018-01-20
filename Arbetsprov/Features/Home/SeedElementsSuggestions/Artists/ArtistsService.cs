using Arbetsprov.Common.SpotifyApi;
using Arbetsprov.Common.SpotifyApi.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arbetsprov.Features.Home.SeedElementsSuggestions.Artists
{
    public class ArtistsService : IArtistsService
    {
        private readonly ISpotifyService _spotifyService;

        public ArtistsService(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<IEnumerable<Artist>> GetArtists(string nameQuery)
        {
            SearchArtistResponse searchArtistResponse = await _spotifyService.SearchArtistsAsync(nameQuery);

            return searchArtistResponse
                .Artists
                .Items;
        }
    }
}