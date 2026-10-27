using Core.Abstraction;

namespace Core.Dtos
{
    public class GetAllSerchHistoryDto:BaseEntityInt
    {
        public string SearchTerm { get; set; }
    }
}
