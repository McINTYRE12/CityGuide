using System.Collections.Generic;
using System.Linq;
using CG.Domain;

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
    }
}
