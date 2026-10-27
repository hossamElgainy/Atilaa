using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.AppVersionDtos
{
    public class AddOrEditAppVersionDto
    {
        public int? Id { get; set; }
        public string GooglePlayLink { get; set; }
        public string GooglePlayVersion { get; set; }
        public string AppStoreLink { get; set; }
        public string AppStoreVersion { get; set; }
    }

}
