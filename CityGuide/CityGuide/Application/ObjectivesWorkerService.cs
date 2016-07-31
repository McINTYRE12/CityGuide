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
                Address = o.Address,
                Location = o.Location
            }).ToList();
        }
        [HttpPost]
        public List<ObjectiveViewModel> GetObjectivesFromCategory(int id, string sortOrder)
        {

            List<Objective> objectives = _db.GetObjectivesFromCategory(id);

            foreach(var obj in objectives)
            {
                var avg = 0;
                var num = 0;
                if (obj.Reviews.Any())
                {
                    foreach (var rev in obj.Reviews)
                    {
                        num++;
                        avg += rev.ScoreGiven;
                    }
                }
                if (num != 0)
                {
                    avg = avg / num;
                    obj.Score = avg;
                }
                else
                {
                    obj.Score = 0;
                }
            }

            var objs = objectives.Select(o => new ObjectiveViewModel
            {
                Name = o.Name,
                Photos = o.Photos,
                Score = o.Score,
                Id = o.Id,
                Reviews = o.Reviews,
                Address = o.Address,
                Location = o.Location
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
                Address = o.Address,
                Location = o.Location
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

        public ObjectiveViewModel GetObjectiveByID(int ObjectiveID)
        {
            var obj = _db.GetObjectiveByID(ObjectiveID);
            if(obj == null)
            {
                return null;
            }
            var avg = 0;
            var num = 0;

            foreach(var rev in obj.Reviews)
            {
                avg += rev.ScoreGiven;
                num++;
            }
            if (num == 0)
                avg = 0;
            else
                avg = avg / num;
            return new ObjectiveViewModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Photos = obj.Photos,
                Reviews = obj.Reviews,
                Description = obj.Description,
                Address = obj.Address,
                Score = avg,
                Location = obj.Location
            };
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
    }
}