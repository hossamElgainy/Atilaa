namespace Core.Dtos
{
    public class AddReviewDto
    {
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public int SessionId { get; set; }
        public decimal Rate { get; set; }
        public string ReviewText { get; set; }

    }
}
