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
        private ToursWorkerService _toursWorkerSvc;
        private UsersWorkerService _usersWorkerSvc;

        public ToursController(ToursWorkerService toursService, UsersWorkerService usersService)
        {
            _toursWorkerSvc = toursService;
            _usersWorkerSvc = usersService;
        }

        public ActionResult Index()
        {
            return View(_toursWorkerSvc.GetAllTours());
        }

        public ActionResult Search(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(_toursWorkerSvc.SearchTours(searchString));
            }
            else
                return View(_toursWorkerSvc.GetAllTours());
        }

        public ActionResult Details(int id)
        {
            return View(_toursWorkerSvc.GetTourById(id));
        }

        [Authorize]
        public ActionResult Create()
        {
            List<ObjectiveViewModel> objs = _toursWorkerSvc.GetObjectivesForDropdown();

            return View(objs);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(string TourTitle, List<int> obj, List<Transport> transport)
        {
            var tour = new Tour();
            var j = 0;
            var id = 0;
            var ObjTours = new List<ObjectiveTour>();
            tour.Transports = new List<Transport>();

            tour.Name = TourTitle;
            tour.Stops = obj.Count();
            tour.Rating = 3;
            tour.User = _usersWorkerSvc.GetUserFromFacebookID(Session["FacebookID"].ToString());
            tour.Transports.AddRange(transport);

            db.Tours.Add(tour);
            db.SaveChanges();

            id = _toursWorkerSvc.GetLastTourID();

            foreach (var i in obj)
            {
                db.ObjectiveTour.Add(new ObjectiveTour { ObjectiveId = i, TourId = id, SortOrder = j++ });
            }

            db.SaveChanges();
            return Redirect("/Tours/Index");
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
