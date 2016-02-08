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
        public List<Photo> Photos { get; set; }
    }
}
