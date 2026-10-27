namespace Core.Dtos
{
    public class NotificationVm
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}
