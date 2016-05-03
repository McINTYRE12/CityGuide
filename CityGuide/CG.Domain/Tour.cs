using System.Collections.Generic;

namespace CG.Domain
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stops { get; set; }
        public virtual List<Objective> Objectives { get; set; }
        public virtual List<Photo> Transition_photos { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
    }
}