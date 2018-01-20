using Arbetsprov.Common.SpotifyApi;
using Arbetsprov.Common.SpotifyApi.ResponseModels;
using Arbetsprov.Features.Home.SeedElementsSuggestions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbetsprov.Features.Recommendations
{
    public class RecommendationsService : IRecommendationsService
    {
        private const string ArtistsListSeparator = ", ";
        private const string PageName = "Recommendations Search Result";

        private readonly ISpotifyService _spotifyService;

        public RecommendationsService(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<RecommendationsViewModel> GetRecommendationsAsync(IEnumerable<string> preferedMusic, int energyPercent)
        {
            (IEnumerable<string> artistsIds, IEnumerable<string> genresIds) = GetArtistsAndGenresIds(preferedMusic);

            RecommendationsResponse recommendationsResponse = await _spotifyService.GetRecommendationsAsync(artistsIds, genresIds, energyPercent);
            IEnumerable<RecommendationViewModel> recommendations = recommendationsResponse.Tracks
                .Select(CreateRecommendationViewModel);

            return new RecommendationsViewModel(PageName, recommendations);
            
        }

        private RecommendationViewModel CreateRecommendationViewModel(Track track)
        {
            IEnumerable<string> artistNames = track.Artists
                .Select(artist => artist.Name);

            string artistName = string.Join(ArtistsListSeparator, artistNames);
            string songTitle = track.Name;
            string songId = track.Id;

            return new RecommendationViewModel(artistName, songTitle, songId);
        }

        private (IEnumerable<string>, IEnumerable<string>) GetArtistsAndGenresIds(IEnumerable<string> elementIds)
        {
            var artistsIds = new List<string>();
            var genresIds = new List<string>();

            foreach (var elementId in elementIds)
            {
                string[] splitId = elementId.Split(SeedElementsSuggestion.IdGroupValueSeparator);
                if (splitId.Count() != 2)
                {
                    continue;
                }

                string groupId = splitId[0];
                string suggestionId = splitId[1];

                if (groupId == SeedElementsSuggestion.ArtistsGroupId)
                {
                    artistsIds.Add(suggestionId);
                } else if (groupId == SeedElementsSuggestion.GenreGroupId)
                {
                    genresIds.Add(suggestionId);
                }
            }

            return (artistsIds, genresIds);
        }
    }
}