using CG.DataAccess;
using CG.Domain;
using CityGuide.Application;
using CityGuide.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CityGuide.Controllers
{
    public class ToursController : Controller
    {
        private CityGuideContext db = new CityGuideContext();
        private ObjectivesWorkerService _objWorkerSvc;

        public ToursController(ObjectivesWorkerService objService)
        {
            _objWorkerSvc = objService;
        }

        public ActionResult Index()
        { 
            return View(db.Tours.ToList());
        }

        public ActionResult Search(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(db.Tours.Where(s => s.Name.Contains(searchString)).ToList());
            }
            else
                return View(db.Tours.ToList());
        }

        // GET: Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        [Authorize]
        public ActionResult Create()
        {
            List<ObjectiveViewModel> objs = _objWorkerSvc.GetObjectivesForDropdown();

            return View(objs);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(List<int> obj, List<int> transport)
        {
            var tour = new Tour();
            var j = 0;
            var objs = new List<Objective>();
            tour.Transports = new List<int>();
            tour.Objectives = new List<Objective>();

            tour.Name = "test1";
            tour.Stops = obj.Count();
            tour.Rating = 3;
            tour.UserID = 1;
            tour.Transports.AddRange(transport);

            foreach(var i in obj)
            {
                objs.Add(db.Objectives.Where(o => o.Id == i).First());
            }

            tour.Objectives.AddRange(objs);

            db.Tours.Add(tour);
            db.SaveChanges();
            return Index();
        }

        // GET: Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Stops,UserID")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tour);
        }

        // GET: Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
