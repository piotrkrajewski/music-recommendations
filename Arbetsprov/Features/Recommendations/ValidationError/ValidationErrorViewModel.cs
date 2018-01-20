using Arbetsprov.Features.Shared;

namespace Arbetsprov.Features.Recommendations.ValidationError
{
    public class ValidationErrorViewModel : PageBase
    {
        public readonly string ErrorMessage;

        public ValidationErrorViewModel(string pageName, string errorMessage) : base(pageName)
        {
            ErrorMessage = errorMessage;
        }
    }
}