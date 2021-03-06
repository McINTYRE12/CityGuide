﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CG.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public int ReviewScore { get; set; }
        public int ScoreGiven { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public string Title { get; set; }
        public virtual Objective Objective { get; set; }
        public virtual User User { get; set; }
        public string Date { get; set; }
    }

    public class TourReview
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Tour Tour { get; set; }
        public int ScoreGiven { get; set; }
    }
}
