using CameraServicesPlatform.BackEnd.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Account : IdentityUser
    {
        public string AccountName { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /*[ForeignKey("Role")]
        public Guid RoleID { get; set; }
        public Role Role { get; set; }
*/
        public Gender Gender { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsVerified { get; set; } = false;

        [MaxLength(255)]
        public string? VerifyCode { get; set; }

        [MaxLength(255)]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        [MaxLength(255)]
        public string? ProfileImage { get; set; }
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
