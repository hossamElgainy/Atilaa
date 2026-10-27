using Core.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.DomainModels
{
    public class Review:BaseEntityInt
    {
        [Column(TypeName = "decimal(3,2)")]
        public decimal Rate { get; set; }
        public string ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int CaptainId { get; set; }
        public Captain Captain { get; set; }
        public int? FacilityId { get; set; }
        public Facility? Facility { get; set; }
        public bool DoneByCaptain { get; set; }
    }
}
