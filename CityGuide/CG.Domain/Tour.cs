using System.Collections.Generic;

namespace CG.Domain
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stops { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
    }

    public class ObjectiveTour
    {
        public int Id { get; set; }
        public int FromObj { get; set; }
        public int ToObj { get; set; }
        public int Transport { get; set; }
    }
}