namespace Arbetsprov.Features.Recommendations
{
    public class RecommendationViewModel
    {
        public readonly string ArtistName;
        public readonly string SongTitle;
        public readonly string SongId;

        public RecommendationViewModel(string artistName, string songTitle, string songId)
        {
            ArtistName = artistName;
            SongTitle = songTitle;
            SongId = songId;
        }
    }
}