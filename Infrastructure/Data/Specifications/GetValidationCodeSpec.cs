using AshalLms.Core.DomainModels.UsersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Specifications
{
    public class GetValidationCodeSpec:BaseSpecification<ValidationCode>
    {
        public GetValidationCodeSpec(int UserId):base()
        {
            Criteria.Add(x => x.UserId == UserId);
            OrderByDesc = x => x.GeneratedDate;
        }
    }
}
