using Arbetsprov.Features.Recommendations.ValidationError;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Arbetsprov.Features.Recommendations
{
    public class RecommendationsController : Controller
    {
        private const string ErrorPageName = "Error";
        private readonly IRecommendationsService _recommendationsService;

        public RecommendationsController(IRecommendationsService recommendationsService)
        {
            _recommendationsService = recommendationsService;
        }

        public async Task<ActionResult> Index(IList<string> preferedMusic, int energy)
        {
            if (preferedMusic == null || preferedMusic.Count == 0 || preferedMusic.Count > 5)
            {
                string errorMessage = "Choose a minimum of 1 and a maximum of 5 elements!";

                return View("ValidationError/Index", new ValidationErrorViewModel(ErrorPageName, errorMessage));
            }

            if (energy < 0 || energy > 100)
            {
                string errorMessage = "Energy percent must be between 0 and 100";

                return View("ValidationError/Index", new ValidationErrorViewModel(ErrorPageName, errorMessage));
            }

            RecommendationsViewModel recommendations = await _recommendationsService.GetRecommendationsAsync(preferedMusic, energy);

            return View(recommendations);
        }
    }
}