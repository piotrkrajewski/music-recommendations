using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arbetsprov.Features.Recommendations
{
    public interface IRecommendationsService
    {
        Task<RecommendationsViewModel> GetRecommendationsAsync(IEnumerable<string> artistsIds, int energyPercent);
    }
}
