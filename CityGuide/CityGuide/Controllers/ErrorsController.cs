using System.Web.Mvc;

namespace CityGuide.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult Error404()
        {
            return View();
        }
    }
}