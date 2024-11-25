using CameraServicesPlatform.BackEnd.Domain.Enum.Account;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using Microsoft.AspNetCore.Http;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request;
public class UpdateAccountRequestDTO
{
    public string Email { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public JobStatus? Job { get; set; }
    public HobbyStatus? Hobby { get; set; }
    public Gender Gender { get; set; }
    public IFormFile? FrontOfCitizenIdentificationCard { get; set; }
    public IFormFile? BackOfCitizenIdentificationCard { get; set; }
    public IFormFile? Img { get; set; }

    public string? BankName { get; set; }

    public string? AccountNumber { get; set; }

    public string? AccountHolder { get; set; }
}