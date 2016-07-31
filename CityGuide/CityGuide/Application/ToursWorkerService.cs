using CG.Domain;
using CityGuide.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityGuide.Application
{
    public class ToursWorkerService
    {
        private ICityGuideDatabase _db;

        public ToursWorkerService(ICityGuideDatabase db)
        {
            _db = db;
        }

        public List<ObjectiveViewModel> GetObjectivesForDropdown()
        {
            List<Objective> objs = _db.GetAllObjectives();

            return objs.Select(o => new ObjectiveViewModel
            {
                Id = o.Id,
                Name = o.Name
            }).ToList();
        }

        public int GetRatingOfTour(int id)
        {
            List<TourReview> reviews = _db.GetReviewsForTour(id);
            var avg = 0;
            var num = 0;

            foreach (var rev in reviews)
            {
                num++;
                avg += rev.ScoreGiven;
            }
            if (num != 0)
            {
                avg = avg / num;
            }
            else
            {
                avg = 0;
            }

            return avg;
        }

        public List<TourViewModel> GetAllTours()
        {
            List<Tour> tours = _db.GetAllTours();

            return tours.Select(o => new TourViewModel
            {
                Name = o.Name,
                Id = o.Id,
                Rating = GetRatingOfTour(o.Id),
                Objectives = _db.GetObjectivesForTour(o.Id),
                User = o.User,
                Stops = o.Stops
            }).ToList();
        }

        public int GetLastTourID()
        {
            return _db.GetLastTourId();
        }

        public List<TourViewModel> SearchTours(string name)
        {
            List<Tour> tours = _db.GetAllTours();

            return tours.Where(o => o.Name.Contains(name)).Select(o => new TourViewModel
            {
                Name = o.Name,
                Id = o.Id,
                Objectives = _db.GetObjectivesForTour(o.Id),
                User = o.User,
                Stops = o.Stops
            }).ToList();
        }

        public TourViewModel GetTourById(int id)
        {
            Tour tour = _db.GetTourById(id);
            List<Objective> objectives = _db.GetObjectivesForTour(id);
            List<Transport> transports = _db.GetTransportsForTour(id);
            List<String> info = _db.GetAdditionalInfoForTour(id);

            return new TourViewModel
            {
                Name = tour.Name,
                Objectives = objectives,
                Id = tour.Id,
                Transports = transports,
                Rating = GetRatingOfTour(tour.Id),
                Stops = tour.Stops,
                User = tour.User,
                Info = info
            };
        }
    }
}