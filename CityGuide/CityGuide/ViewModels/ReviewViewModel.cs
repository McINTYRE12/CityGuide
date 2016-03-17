namespace CityGuide.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int ReviewScore { get; set; }
        public int ScoreGiven { get; set; }
        public string Text { get; set; }
    }
}