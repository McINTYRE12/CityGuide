using System.Collections.Generic;

namespace CG.Domain
{
    public interface ICityGuideDatabase
    {
        List<Objective> GetAllObjectives();

        void Commit();
    }
}
