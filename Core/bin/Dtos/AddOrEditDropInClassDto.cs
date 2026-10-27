using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dtos
{
    public class AddOrEditDropInClassDto 
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int CaptainId { get; set; }
        public List<DayOfWeekEnum> Days { get; set; }
        public TimeSpan StartAt { get; set; }
        public bool IsRepeated { get; set; }
        public int MaxJoinersCount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
