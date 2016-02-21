using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CG.DataAccess;
using CG.Domain;
using CityGuide.Application;

namespace CityGuide.Controllers
{
    public class CategoryController : Controller
    {
        private CityGuideContext db = new CityGuideContext();
        private ObjectivesWorkerService _objWorkerSvc;

        public CategoryController(ObjectivesWorkerService objService)
        {
            _objWorkerSvc = objService;
        }

        public ActionResult Details(int? id, string searchString, string sortOrder = "")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = db.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.Objectives = _objWorkerSvc.GetObjectivesFromSearch(id.Value, searchString, sortOrder);
            }
            else
                ViewBag.Objectives = _objWorkerSvc.GetObjectivesFromCategory(id.Value, sortOrder);

            ViewBag.test = _objWorkerSvc.testFunction();

            return View(category);
        }
        
    }
}
