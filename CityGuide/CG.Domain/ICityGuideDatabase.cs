using System.Collections.Generic;

namespace CG.Domain
{
    public interface ICityGuideDatabase
    {
        List<Objective> GetAllObjectives();
        List<Objective> GetObjectivesFromCategory(int id);
        List<Category> GetAllCategories();
        List<Review> GetAllReviews();

        void Commit();
    }
}
