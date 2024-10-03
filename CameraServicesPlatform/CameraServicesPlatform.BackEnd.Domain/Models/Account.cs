using CameraServicesPlatform.BackEnd.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Account : IdentityUser
    {
        // public string AccountName { get; set; }
        public bool EmailConfirmed { get; set; }
        public required string PhoneNumber { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public Gender Gender { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsVerified { get; set; } = false;
        public string? Address { get; set; }
        public string? VerifyCode { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        //public string? ProfileImage { get; set; }
        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        //public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
