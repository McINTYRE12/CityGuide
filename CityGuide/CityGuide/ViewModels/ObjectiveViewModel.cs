using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CG.Domain;
using System.Data.Entity.Spatial;

namespace CityGuide.ViewModels
{
    public class ObjectiveViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Score { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public DbGeography Location { get; set; }
    }
}