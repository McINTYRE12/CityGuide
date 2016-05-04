using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CG.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int ReviewScore { get; set; }
        public int ScoreGiven { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public string Title { get; set; }
        public virtual Objective Objective { get; set; }
    }
}
