using CameraServicesPlatform.BackEnd.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Member
{
    [Key]
    public Guid MemberID { get; set; }

    [ForeignKey(nameof(Account))]
    public string? AccountID { get; set; }

    public Account Account { get; set; }

    public DateTime JoinedAt { get; set; }

    public bool IsActive { get; set; }

     public OrderHistory OrderHistory { get; set; }
}
