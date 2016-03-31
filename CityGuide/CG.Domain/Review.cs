using System.Collections.Generic;

namespace CG.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int ReviewScore { get; set; }
        public int ScoreGiven { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
