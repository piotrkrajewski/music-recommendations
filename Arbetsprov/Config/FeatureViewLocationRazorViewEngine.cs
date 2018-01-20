using System.Web.Mvc;

namespace Arbetsprov.Config
{
    public class FeatureViewLocationRazorViewEngine : RazorViewEngine
    {
        private const string FeatureFolderDirectory = "~/Features";
        private const string SharedFolderName = "Shared";
        private const string CsHtmlFileExtension = "cshtml";
        private const string VbHtmlFileExtension = "vbhtml";

        public FeatureViewLocationRazorViewEngine()
        {
            var featureFolderViewLocationFormats = new[]
            {
                FeatureFolderDirectory + "/{1}/{0}." + CsHtmlFileExtension,
                FeatureFolderDirectory + "/{1}/{0}." + VbHtmlFileExtension,
                FeatureFolderDirectory + "/" + SharedFolderName + "/{0}." + CsHtmlFileExtension,
                FeatureFolderDirectory + "/" + SharedFolderName + "/{0}." + VbHtmlFileExtension,
            };

            ViewLocationFormats = featureFolderViewLocationFormats;
            MasterLocationFormats = featureFolderViewLocationFormats;
            PartialViewLocationFormats = featureFolderViewLocationFormats;
        }
    }
}