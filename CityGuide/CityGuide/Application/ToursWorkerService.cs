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

        public List<TourViewModel> GetAllTours()
        {
            List<Tour> tours = _db.GetAllTours();

            return tours.Select(o => new TourViewModel
            {
                Name = o.Name,
                Id = o.Id,
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
    }
}