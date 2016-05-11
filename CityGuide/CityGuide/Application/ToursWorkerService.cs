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
    }
}