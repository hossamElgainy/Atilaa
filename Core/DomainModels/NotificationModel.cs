
using Core.Abstraction;
using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.DomaimModels
{
    public class NotificationModel:BaseEntityInt
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public ServicesEnum ServiceName { get; set; }
        public DateTime Date { get; set; }
        public RolesEnum Role { get; set; }
    }
}
