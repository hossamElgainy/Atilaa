namespace Core.Dtos
{
    public class ReviewsSammaryDto
    {
        public decimal Rate { get; set; }
        public int ReviewsCount { get; set; }
        public int OneStar { get; set; }
        public int TwoStar { get; set; }
        public int ThreeStar { get; set; }
        public int FourStar { get; set; }
        public int FiveStar { get; set; }
    }
}
