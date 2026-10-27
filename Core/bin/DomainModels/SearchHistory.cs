using Core.Abstraction;

namespace Core.DomainModels
{
    public class SearchHistory:BaseEntityInt
    {
        public string SearchTerm { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }



}
