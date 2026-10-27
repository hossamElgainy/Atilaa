using Core.Enums;

namespace Core.Dtos
{
    public class SendNotificationVm
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int? CustomId { get; set; }
    }
    
}
