using System.Collections.Generic;

namespace CG.Domain
{
    public interface ICityGuideDatabase
    {
        List<Objective> GetAllObjectives();
        List<Objective> GetObjectivesFromCategory(int id);
        List<Category> GetAllCategories();
        List<Photo> GetAllPhotos();
        List<Photo> GetPhotosOfObjective(int id);

        void Commit();
    }
}
