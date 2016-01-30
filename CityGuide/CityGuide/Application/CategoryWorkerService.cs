using CG.Domain;
using CityGuide.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CityGuide.Application
{
    public class CategoriesWorkerService
    {
        private ICityGuideDatabase _db;

        public CategoriesWorkerService(ICityGuideDatabase db)
        {
            _db = db;
        }

        public List<CategoryViewModel> GetAllCategories()
        {

            List<Category> categories = _db.GetAllCategories();

            return categories.Select(o => new CategoryViewModel
            {
                Name = o.Name
            }).ToList();
        }
    }
}