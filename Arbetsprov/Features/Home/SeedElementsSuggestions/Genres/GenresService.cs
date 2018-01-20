using Arbetsprov.Common.SpotifyApi;
using Arbetsprov.Common.SpotifyApi.ResponseModels;
using Arbetsprov.Common.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbetsprov.Features.Home.SeedElementsSuggestions.Genres
{
    public class GenresService : IGenresService
    {
        private readonly ISpotifyService _spotifyService;
        private readonly ITextService _textService;

        public GenresService(ISpotifyService spotifyService, ITextService textService)
        {
            _spotifyService = spotifyService;
            _textService = textService;
        }

        public async Task<IEnumerable<Genre>> GetGenres(string query)
        {
            GenreResponse searchGenreResponse = await _spotifyService.GetGenresAsync();

            return searchGenreResponse.Genres
                .Select(GetGenreObject)
                .Where(genre => MatchesQuery(genre, query));
        }

        private Genre GetGenreObject(string genreId)
        {
            string id = genreId;

            string genreWithSpaces = genreId.Replace("_", " ");
            string text = _textService.CapitalizeFirstLetters(genreWithSpaces);

            return new Genre(id, text);
        }

        private bool MatchesQuery(Genre genre, string query)
        {
            string lowercaseQuery = query.ToLower();

            return genre.Text
                .ToLower()
                .StartsWith(lowercaseQuery);
        }
    }
}