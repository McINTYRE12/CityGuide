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

        public User GetUserFromFacebookID(string FacebookID)
        {
            return _db.GetUserFromFacebookID(FacebookID);
        }

    }
}