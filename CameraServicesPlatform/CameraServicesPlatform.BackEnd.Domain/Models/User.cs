using CameraServicesPlatform.BackEnd.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
    public class User : IdentityUser
    {
    [Key] public Guid UserId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public string? Address { get; set; }

        public Gender Gender { get; set; }
        public Guid? RoleId { get; set; }

        public string? ProfileImage { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public bool IsVerified { get; set; } = false;
        public string? VerifyCode { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
    }

