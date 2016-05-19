using System.Collections.Generic;

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
        public virtual List<Tour> Tours { get; set; }
    }
}
