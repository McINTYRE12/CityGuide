using System.Collections.Generic;
using System.Linq;
using CG.Domain;
using CityGuide.ViewModels;

namespace CityGuide.Application
{
    public class ObjectivesWorkerService
    {
        private ICityGuideDatabase _db;

        //1. get a referecne to a DB instance
        public ObjectivesWorkerService(ICityGuideDatabase db)
        {
            _db = db;
        }

        public List<ObjectiveViewModel> GetAllObjectives()
        {

            // 2. cal method on DB "object" to get all objetives
            List<Objective> objectives = _db.GetAllObjectives();

            // 3. map list of objectives to view model class
            return objectives.Select(o => new ObjectiveViewModel
            {
                Name = o.Name,
                Photos = o.Photos,
                Id = o.Id
            }).ToList();
        }

        public List<ObjectiveViewModel> GetObjectivesFromCategory(int id)
        {

            List<Objective> objectives = _db.GetAllObjectives();
            List<Photo> photos = _db.GetAllPhotos();

            return objectives.Where(o => o.Category == id).Select(o => new ObjectiveViewModel
            {
                Name = o.Name,
                Photos = o.Photos,
                Id = o.Id
            }).ToList();
        }
    }
}