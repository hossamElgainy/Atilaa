
using Core.Abstraction;

namespace AshalLms.Core.DomainModels.UsersModels
{
    public class ValidationCode : BaseEntityInt
    {
        public int UserId { get; set; }

        public string Code { get; set; } = null!;

        public DateTime GeneratedDate { get; set; }

        public DateTime ExpirationDate { get; set; }

    }
}
