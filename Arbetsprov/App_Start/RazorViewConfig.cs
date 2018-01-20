using Arbetsprov.Config;
using System.Web.Mvc;

namespace Arbetsprov
{
    public class RazorViewConfig
    {
        internal static void RegisterEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new FeatureViewLocationRazorViewEngine());
        }
    }
}