using System.Web.Optimization;

namespace Arbetsprov
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/bower_components/jquery/dist/jquery.min.js",
                "~/bower_components/bootstrap/dist/js/bootstrap.min.js",
                "~/bower_components/select2/dist/js/select2.full.min.js",
                "~/bower_components/seiyria-bootstrap-slider/dist/bootstrap-slider.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Features/Home/SeedElementsSuggestions/seed-elements-suggestions.js",
                "~/Features/Home/slider.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/bower_components/bootstrap/dist/css/bootstrap.min.css",
                "~/bower_components/bootstrap/dist/css/bootstrap-grid.min.css",
                "~/bower_components/select2/dist/css/select2.min.css",
                "~/bower_components/seiyria-bootstrap-slider/dist/css/bootstrap-slider.min.css",
                "~/Features/Shared/layout.css",
                "~/Features/Recommendations/recommendations.css",
                "~/Features/Home/SeedElementsSuggestions/seed-elements-suggestions.css"
           ));

           BundleTable.EnableOptimizations = true;
        }
    }
}
