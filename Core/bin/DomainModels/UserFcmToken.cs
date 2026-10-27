using System.ComponentModel.DataAnnotations;

namespace Core.DomainModels
{
    public class UserFcmToken
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        public string AppType { get; set; } = "Player";        // "Player" or "FacilityCaptain"

        [Required]
        public string FcmToken { get; set; } = string.Empty;

        public string? DeviceId { get; set; }                  // Helps identify same physical device

        public string DeviceType { get; set; } = "Android";    // Android / iOS

        public DateTime LastRegistered { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}
