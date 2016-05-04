using CG.Domain;

namespace CityGuide.Application
{
    public class UsersWorkerService
    {
        private ICityGuideDatabase _db;

        public UsersWorkerService(ICityGuideDatabase db)
        {
            _db = db;
        }

        public int GetUserIdFromFacebookID(string FacebookID)
        {
            return _db.GetUserIdFromFacebookID(FacebookID);
        }

    }
}