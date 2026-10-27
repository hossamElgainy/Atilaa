using Core.Abstraction;

namespace Core.Dtos
{
    public class GetAllSportsDto:BaseEntityInt
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public List<GetBreifTraineesDto> Trainees { get; set; }
        public int TraineesCount { get; set; }
        public bool IsFavourite { get; set; }
    }
}
