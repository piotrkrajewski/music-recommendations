using Arbetsprov.Common.Text;
using Arbetsprov.Features.Recommendations;
using Arbetsprov.Common.SpotifyApi;
using Arbetsprov.Features.Home.SeedElementsSuggestions;
using Arbetsprov.Features.Home.SeedElementsSuggestions.Artists;
using Arbetsprov.Features.Home.SeedElementsSuggestions.Genres;
using System;
using Unity;

namespace Arbetsprov
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISeedElementsSuggestionsService, SeedElementsSuggestionsService>();
            container.RegisterType<IArtistsService, ArtistsService>();
            container.RegisterType<IGenresService, GenresService>();
            container.RegisterType<ISpotifyService, SpotifyService>();
            container.RegisterType<IRecommendationsService, RecommendationsService>();
            container.RegisterType<ITextService, TextService>();
        }
    }
}