using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Account;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Account : IdentityUser
    {
        public bool EmailConfirmed { get; set; }
        public required string PhoneNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public JobStatus? Job { get; set; }
        public HobbyStatus? Hobby { get; set; }
        public Gender Gender { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsVerified { get; set; } = false;
        public string? Address { get; set; }
        public string? VerifyCode { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public string? SupplierID { get; set; }
        [JsonIgnore] public Supplier? Supplier { get; set; } // Reference to Supplier, consider limiting its data exposure
        public string? StaffID { get; set; }
        [JsonIgnore] public Staff? Staff { get; set; } // Reference to Staff, consider limiting its data exposure
        public string? Img { get; set; }
        public string? FrontOfCitizenIdentificationCard { get; set; }
        public string? BackOfCitizenIdentificationCard { get; set; }
    }
}
