using Core.Abstraction;

namespace Core.DomainModels
{
    public class Voacher:BaseEntityInt
    {
        public int PointsPerBooking { get; set; }
        public int PointsPerAttendSession { get; set; }
        public int PointsPerDailyLogin { get; set; }
        public int PointsPerPound { get; set; }
    }
}
