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
            }

            Commit();
        }

        public Objective GetObjectiveByID(int ObjectiveID)
        {
            return _ctx.Objectives.Where(c => c.Id == ObjectiveID).First();
        }

        public User GetUserFromFacebookID(string FacebookID)
        {
            return _ctx.Users.Where(c => c.FacebookID == FacebookID.ToString()).First();
        }
    }
}
