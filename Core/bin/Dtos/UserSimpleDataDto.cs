using Core.Abstraction;

namespace Core.Dtos
{
    public class UserSimpleDataDto:BaseEntityInt
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
