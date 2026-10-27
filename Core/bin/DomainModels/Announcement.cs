using Core.Abstraction;

namespace Core.DomainModels
{
    public class Announcement : BaseEntityInt
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public string? Url { get; set; }
    }


}
