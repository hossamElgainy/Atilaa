using Core.Abstraction;

namespace Core.DomainModels
{
    public class CaptainWork:BaseEntityInt
    {
        public int CaptainId { get; set; }
        public Captain Captain { get; set; }
        public string Url { get; set; }
        public bool Image { get; set; }
    }
}
