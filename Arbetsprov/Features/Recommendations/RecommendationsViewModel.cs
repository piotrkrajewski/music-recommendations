using Arbetsprov.Features.Shared;
using System.Collections.Generic;

namespace Arbetsprov.Features.Recommendations
{
    public class RecommendationsViewModel : PageBase
    {
        public readonly IEnumerable<RecommendationViewModel> Recommendations;

        public RecommendationsViewModel(string pageName, IEnumerable<RecommendationViewModel> recommendations) : base(pageName)
        {
            Recommendations = recommendations;
        }
    }
}