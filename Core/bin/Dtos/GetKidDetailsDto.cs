using Core.Abstraction;

namespace Core.Dtos
{
    public class GetKidDetailsDto
    {
        public int KidId { get; set; }
        public int TraineeId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public int NoOfSessions { get; set; }
        public string Diseases { get; set; }
        public GetKidOverViewDto OverView { get; set; }
        public List<GetKidNotesDto> Notes { get; set; }
        public List<GetKidPlansForCaptainDto> Plans { get; set; }
    }
}
