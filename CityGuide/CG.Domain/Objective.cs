using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace CG.Domain
{
    public class Objective
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int Category { get; set; }
        public string Address { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public DbGeography Location { get; set; }
    }

    public class ObjectiveTour
    {
        public int Id { get; set; }
        public int ObjectiveId { get; set; }
        public int TourId { get; set; }
        public int SortOrder { get; set; }
    }
}
