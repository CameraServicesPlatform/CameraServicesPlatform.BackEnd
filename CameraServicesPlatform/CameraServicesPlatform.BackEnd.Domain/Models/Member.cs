using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Member
{
    [Key]
    public Guid MemberID { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;

    public Gender Gender { get; set; }
    public DateTime Dob { get; set; }
    public bool IsAdult { get; set; }
    public double Money { get; set; }
    [ForeignKey(nameof(Account))]
    public string? AccountID { get; set; }

    public Account Account { get; set; }

    public DateTime JoinedAt { get; set; }

    public bool IsActive { get; set; }
    public bool? IsVerfiedPhoneNumber { get; set; } = false;
    public bool? IsVerifiedEmail { get; set; } = false;
    public string? VerficationCodePhoneNumber { get; set; }
    public string? VerficationCodeEmail { get; set; }
    public OrderHistory? OrderHistory { get; set; }
}
