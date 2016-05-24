using System.Collections.Generic;

namespace CG.Domain
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stops { get; set; }
        public virtual User User { get; set; }
        public int Rating { get; set; }
        public List<Transport> Transports { get; set; }
    }

    public class Transport
    {
        public int Id { get; set; }
    }
}