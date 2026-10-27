// using Core.Enums;
// using Microsoft.AspNetCore.Mvc;
// using System.Data;
// using System.Net.NetworkInformation;
// using System.Runtime.InteropServices.JavaScript;
// using System.Xml.Linq;

// namespace APIS.Controllers
// {

//     public class EnumsController : APIBaseController
//     {
//         private static readonly Type[] MyEnumTypes = new[]
//         {
//             typeof(BookingTypeEnum),
//         };

//         [HttpGet]
//         public IActionResult GetAllEnumNames()
//         {
//             var result = MyEnumTypes
//                 .Select(t => new
//                 {
//                     Name = t.Name,
//                     FullName = t.FullName
//                 })
//                 .OrderBy(x => x.Name)
//                 .ToList();

//             return Ok(result);
//         }

//         [HttpGet("{enumName}")]
//         public IActionResult GetEnumValues(string enumName)
//         {
//             var enumType = MyEnumTypes
//                 .FirstOrDefault(t =>
//                     string.Equals(t.Name, enumName, StringComparison.OrdinalIgnoreCase) ||
//                     string.Equals(t.FullName, enumName, StringComparison.OrdinalIgnoreCase));

//             if (enumType == null || !enumType.IsEnum)
//             {
//                 return NotFound(new
//                 {
//                     message = $"Enum '{enumName}' not found",
//                     available = MyEnumTypes.Select(t => t.Name).OrderBy(n => n)
//                 });
//             }

//             var values = Enum.GetValues(enumType)
//                 .Cast<Enum>()
//                 .Select(e => new
//                 {
//                     Name = e.ToString(),
//                     Value = Convert.ToInt32(e)
//                 })
//                 .OrderBy(x => x.Value)
//                 .ToList();

//             return Ok(new
//             {
//                 EnumName = enumType.Name,
//                 Values = values
//             });
//         }
//     }
// }
