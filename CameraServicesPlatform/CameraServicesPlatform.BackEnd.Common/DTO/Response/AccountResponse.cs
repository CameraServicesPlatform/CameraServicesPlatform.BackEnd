using CameraServicesPlatform.BackEnd.Domain.Enum;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class AccountResponse
    {
        public string Id { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Gender Gender { get; set; }
        public object Role { get; set; }

         public string? SupplierID { get; set; }
        public Supplier? Supplier { get; set; }
 
        public bool IsDeleted { get; set; }
        public bool IsVerified { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? ProfileImage { get; set; }
        public string MainRole { get; set; }

        public string Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
