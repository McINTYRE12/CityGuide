using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityGuide.Application;

namespace CityGuide.Controllers
{
    public class HomeController : Controller
    {
        private ObjectivesWorkerService _objWorkerSvc;

        public HomeController(ObjectivesWorkerService objService)
        {
            _objWorkerSvc = objService;
        }

        public ActionResult Index()
        {
            var viewModels = _objWorkerSvc.GetAllObjectives();
            return View(viewModels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}