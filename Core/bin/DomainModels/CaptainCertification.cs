using Core.Abstraction;

namespace Core.DomainModels
{
    public class CaptainCertification:BaseEntityInt
    {
        public int CaptainId { get; set; }
        public Captain Captain { get; set; }
        public string Url { get; set; }
    }
}
