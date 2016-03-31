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

    }
}