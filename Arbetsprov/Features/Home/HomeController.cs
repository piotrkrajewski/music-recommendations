using Arbetsprov.Features.Shared;
using System.Web.Mvc;

namespace Arbetsprov.Features.Home
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new PageBase("Music recommendations");

            return View(model);
        }
    }
}