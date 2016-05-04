using System.Collections.Generic;
using System.Linq;
using CG.Domain;
using CityGuide.ViewModels;
using System.Web.Mvc;

namespace CityGuide.Application
{
    public class ObjectivesWorkerService
    {
        private ICityGuideDatabase _db;

        public ObjectivesWorkerService(ICityGuideDatabase db)
        {
            _db = db;
        }

        public List<ObjectiveViewModel> GetAllObjectives()
        {

            List<Objective> objectives = _db.GetAllObjectives();

            return objectives.Select(o => new ObjectiveViewModel
            {
                Name = o.Name,
                Photos = o.Photos,
                Score = o.Score,
                Id = o.Id,
                Reviews = o.Reviews,
                Address = o.Address
            }).ToList();
        }
        [HttpPost]
        public List<ObjectiveViewModel> GetObjectivesFromCategory(int id, string sortOrder)
        {

            List<Objective> objectives = _db.GetObjectivesFromCategory(id);

            var objs = objectives.Select(o => new ObjectiveViewModel
            {
                Name = o.Name,
                Photos = o.Photos,
                Score = o.Score,
                Id = o.Id,
                Reviews = o.Reviews,
                Address = o.Address
            }).ToList();

            switch (sortOrder)
            {
                case "name_desc":
                    return objs.OrderByDescending(s => s.Name).ToList();
                case "score":
                    return  objs.OrderBy(s => s.Score).ToList();
                case "score_desc":
                    return  objs.OrderByDescending(s => s.Score).ToList();
                default:
                    return objs.OrderBy(s => s.Name).ToList();
            }
        }

        [HttpPost]
        public List<ObjectiveViewModel> GetObjectivesFromSearch(int id, string searchString, string sortOrder)
        {

            List<Objective> objectives = _db.GetAllObjectives();

            var objs =  objectives.Where(o => o.Name.Contains(searchString) && o.Category == id).Select(o => new ObjectiveViewModel
            {
                Name = o.Name,
                Photos = o.Photos,
                Score = o.Score,
                Id = o.Id,
                Reviews = o.Reviews,
                Address = o.Address
            }).ToList();

            switch (sortOrder)
            {
                case "name_desc":
                    return objs.OrderByDescending(s => s.Name).ToList();
                case "score":
                    return objs.OrderBy(s => s.Score).ToList();
                case "score_desc":
                    return objs.OrderByDescending(s => s.Score).ToList();
                default:
                    return objs.OrderBy(s => s.Name).ToList();
            }
        }

        public Objective GetObjectiveByID(int ObjectiveID)
        {
            return _db.GetObjectiveByID(ObjectiveID);
        }
    }
}