using CG.Domain;
using CityGuide.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CityGuide.Application
{
    public class PhotosWorkerService
    {
        private ICityGuideDatabase _db;

        public PhotosWorkerService(ICityGuideDatabase db)
        {
            _db = db;
        }

        public List<PhotoViewModel> GetAllPhotos()
        {

            List<Photo> photos = _db.GetAllPhotos();

            return photos.Select(o => new PhotoViewModel
            {
                Url = o.Url,
                Id = o.Id
            }).ToList();
        }
    }
}