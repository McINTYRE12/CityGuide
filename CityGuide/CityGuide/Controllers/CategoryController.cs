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

        public ActionResult Details(int? id)
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
            ViewBag.Objectives = _objWorkerSvc.GetObjectivesFromCategory(id.Value);
            return View(category);
        }
        
    }
}
