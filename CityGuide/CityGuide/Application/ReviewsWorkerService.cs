using CG.Domain;
using CityGuide.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CityGuide.Application
{
    public class ReviewsWorkerService
    {
        private ICityGuideDatabase _db;

        public ReviewsWorkerService(ICityGuideDatabase db)
        {
            _db = db;
        }

        /*public List<ReviewViewModel> GetAllReviews()
        {

            List<Review> reviews = _db.GetAllReviews();

            return reviews.Select(r => new ReviewViewModel
            {
                IdUser = r.IdUser,
                Id = r.Id,
                ReviewScore = r.ReviewScore,
                ScoreGiven = r.ScoreGiven,


            }).ToList();
        }*/
    }
}