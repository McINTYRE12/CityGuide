using CG.Domain;

namespace CityGuide.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int ReviewScore { get; set; }
        public int ScoreGiven { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
    }
}