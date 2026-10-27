namespace Core.Interfaces.IServices.UsersIServices
{
    public class GetTraineeProgressDto
    {
        public int NoOfSessions { get; set; }
        public int NoOfAttendedSessions { get; set; }
        public int NoOfMissedSessions => NoOfSessions - NoOfAttendedSessions;
    }
}
