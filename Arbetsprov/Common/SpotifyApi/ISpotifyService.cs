using Arbetsprov.Common.SpotifyApi.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arbetsprov.Common.SpotifyApi
{
    public interface ISpotifyService
    {
        Task<SearchArtistResponse> SearchArtistsAsync(string query);
        Task<GenreResponse> GetGenresAsync();
        Task<RecommendationsResponse> GetRecommendationsAsync(IEnumerable<string> artistsIds, IEnumerable<string> genresIds, int energyPercent);
    }
}
