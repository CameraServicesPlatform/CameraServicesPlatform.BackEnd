using CameraServicesPlatform.BackEnd.Domain.Enum;
using Microsoft.AspNetCore.Http;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class SignUpRequestDTO
    {
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Gender Gender { get; set; }
        public IFormFile? BackOfCitizenIdentificationCard { get; set; }
        public IFormFile? FrontOfCitizenIdentificationCard { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public   string BankName { get; set; }

        public   string AccountNumber { get; set; }

        public   string AccountHolder { get; set; }
    }
}
