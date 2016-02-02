using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityGuide.ViewModels
{
    public class ObjectiveViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Score { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
    }
}