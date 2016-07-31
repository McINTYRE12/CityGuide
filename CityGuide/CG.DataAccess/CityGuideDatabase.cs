using System.Collections.Generic;
using System.Linq;
using CG.Domain;
using System;

namespace CG.DataAccess
{
    public class CityGuideDatabase : ICityGuideDatabase
    {
        private CityGuideContext _ctx;

        public CityGuideDatabase(CityGuideContext context)
        {
            _ctx = context;
        }

        public void Commit()
        {
            _ctx.SaveChanges();
        }

        public List<Tour> GetAllTours()
        {
            IQueryable<Tour> tours = _ctx.Tours;

            return tours.ToList();
        }

        public List<Objective> GetAllObjectives()
        {
            IQueryable<Objective> objs = _ctx.Objectives;

            return objs.ToList();
        }

        public List<Category> GetAllCategories()
        {
            IQueryable<Category> cats = _ctx.Categories;

            return cats.ToList();
        }

        public List<Objective> GetObjectivesFromCategory(int id)
        {

            IQueryable<Objective> objs = _ctx.Objectives;

            return objs.Where(o => o.Category == id).ToList();
        }

        public List<Review> GetAllReviews()
        {

            IQueryable<Review> reviews = _ctx.Reviews;

            return reviews.ToList();
        }

        public void AddUserToDB(User UserToAdd)
        {
            if(!_ctx.Users.Any(o => o.FacebookID == UserToAdd.FacebookID))
            {
                _ctx.Users.Add(UserToAdd);
                Commit();
            }
        }

        public Objective GetObjectiveByID(int ObjectiveID)
        {
            if (_ctx.Objectives.Where(c => c.Id == ObjectiveID).Any() != false)
                return _ctx.Objectives.Where(c => c.Id == ObjectiveID).First();
            else
                return null;
        }

        public User GetUserFromFacebookID(string FacebookID)
        {
            return _ctx.Users.Where(c => c.FacebookID == FacebookID.ToString()).First();
        }

        public List<Objective> GetObjectivesForTour(int id)
        {
            var ObjTour = _ctx.ObjectiveTour.Where(o => o.TourId == id).OrderBy(o => o.SortOrder).ToList();
            var Objs = new List<Objective>();
            foreach(var i in ObjTour)
            {
                Objs.Add(_ctx.Objectives.Where(o => o.Id == i.ObjectiveId).First());
            }

            return Objs;
        }

        public int GetLastTourId()
        {
            return _ctx.Tours.Max(t => t.Id);
        }

        public Tour GetTourById(int id)
        {
            return _ctx.Tours.Where(t => t.Id == id).First();
        }

        public List<Transport> GetTransportsForTour(int id)
        {
            var TransTour = _ctx.TransportTour.Where(o => o.TourId == id).OrderBy(o => o.SortOrder).ToList();
            var Transports = new List<Transport>();
            foreach (var i in TransTour)
            {
                Transports.Add(_ctx.Transports.Where(o => o.Id == i.TransportId).First());
            }

            return Transports;
        }

        public List<TourReview> GetReviewsForTour(int id)
        {
            return _ctx.TourReviews.Where(o => o.Tour.Id == id).ToList();
        }

        public List<String> GetAdditionalInfoForTour(int id)
        {
            return _ctx.TransportTour.Where(p => p.TourId == id).Select(o => o.Info).ToList();
        }
    }
}
