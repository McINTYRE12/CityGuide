using CG.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityGuide.ViewModels
{
    public class TourViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stops { get; set; }
        public User User { get; set; }
        public int Rating { get; set; }
        public virtual List<Objective> Objectives { get; set; }
        public List<Transport> Transports { get; set; }
    }
}