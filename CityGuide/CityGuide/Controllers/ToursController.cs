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

        [Authorize]
        public ActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(TourReview review, int id)
        {
            var FacebookID = Session["FacebookID"].ToString();

            review.Tour = db.Tours.Where(c => c.Id == id).First();
            review.User = db.Users.Where(c => c.FacebookID == FacebookID.ToString()).First();

            if (review.ScoreGiven != 0)
            {
                db.TourReviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Details/" + id, "Tours");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(string TourTitle, List<int> obj, List<int> transport)
        {
            var tour = new Tour();
            var j = 0;
            var id = 0;
            var ObjTours = new List<ObjectiveTour>();

            tour.Name = TourTitle;
            tour.Stops = obj.Count();
            tour.Rating = 0;
            tour.User = _usersWorkerSvc.GetUserFromFacebookID(Session["FacebookID"].ToString());

            db.Tours.Add(tour);
            db.Entry(tour.User).State = EntityState.Unchanged;
            db.SaveChanges();

            id = _toursWorkerSvc.GetLastTourID();

            foreach (var i in obj)
            {
                db.ObjectiveTour.Add(new ObjectiveTour { ObjectiveId = i, TourId = id, SortOrder = j++ });
            }

            j = 0;

            foreach (var i in transport)
            {
                db.TransportTour.Add(new TransportTour { TransportId = i, TourId = id, SortOrder = j++ });
            }

            db.SaveChanges();
            return Redirect("/Tours/Index");
        }

        [AdminAuthorize]
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
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
