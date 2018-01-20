using Arbetsprov.Common.SpotifyApi.ResponseModels;
using Arbetsprov.Features.Home.SeedElementsSuggestions.Artists;
using Arbetsprov.Features.Home.SeedElementsSuggestions.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbetsprov.Features.Home.SeedElementsSuggestions
{
    public class SeedElementsSuggestionsService : ISeedElementsSuggestionsService
    {
        private const string ArtistsGroupName = "Artists";
        private const string GenresGroupName = "Genres";

        private readonly IArtistsService _artistsService;
        private readonly IGenresService _genresService;

        public SeedElementsSuggestionsService(IArtistsService artistsService, IGenresService genresService)
        {
            _artistsService = artistsService;
            _genresService = genresService;
        }

        public async Task<IEnumerable<SeedElementsSuggestionsGroup>> GetSeedElementsSuggestionsAsync(string query)
        {
            Task<IEnumerable<Artist>> artistsTask = _artistsService.GetArtists(query);
            Task<IEnumerable<Genre>> genresTask = _genresService.GetGenres(query);

            await Task.WhenAll(artistsTask, genresTask);

            IEnumerable<Artist> artists = artistsTask.Result;
            IEnumerable<Genre> genres = genresTask.Result;

            SeedElementsSuggestionsGroup artistsSeedSuggestionsGroup = GetArtistsSeedSuggestionGroup(artists);
            SeedElementsSuggestionsGroup genresSeedSuggestionsGroup = GetGenresSeedSuggestionGroup(genres);

            return new List<SeedElementsSuggestionsGroup>
            {
                genresSeedSuggestionsGroup,
                artistsSeedSuggestionsGroup,
            };
        }

        private SeedElementsSuggestionsGroup GetArtistsSeedSuggestionGroup(IEnumerable<Artist> artists)
        {
            return GetArtistsSeedSuggestionGroup(
                artists,
                SeedElementsSuggestion.ArtistsGroupId,
                artist => artist.Id,
                artist => artist.Name,
                artist => artist.Images.FirstOrDefault()?.Url,
                ArtistsGroupName);
        }

        private SeedElementsSuggestionsGroup GetGenresSeedSuggestionGroup(IEnumerable<Genre> genres)
        {
            return GetArtistsSeedSuggestionGroup(
                genres,
                SeedElementsSuggestion.GenreGroupId,
                genre => genre.Id,
                genre => genre.Text,
                genre => string.Empty,
                GenresGroupName);
        }

        private SeedElementsSuggestionsGroup GetArtistsSeedSuggestionGroup<T>(
            IEnumerable<T> elements,
            string groupId,
            Func<T, string> idSelector,
            Func<T, string> textSelector,
            Func<T, string> imageSelector,
            string groupName)
        {
            IEnumerable<SeedElementsSuggestion> seedElementsSuggestions = elements.Select(element => new SeedElementsSuggestion
            {
                Id = groupId + SeedElementsSuggestion.IdGroupValueSeparator + idSelector(element),
                Text = textSelector(element),
                ImageUrl = imageSelector(element)
            });

            return new SeedElementsSuggestionsGroup
            {
                Text = groupName,
                Children = seedElementsSuggestions
            };
        }
    }
}