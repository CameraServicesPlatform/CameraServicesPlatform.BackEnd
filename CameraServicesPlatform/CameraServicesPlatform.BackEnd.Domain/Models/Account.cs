using CameraServicesPlatform.BackEnd.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class Account : IdentityUser
{
    [Key]
    public Guid AccountID { get; set; }

    [MaxLength(255)]
    public   string AccountName { get; set; }

    [MaxLength(255)]
    public   string Email { get; set; }

    public bool EmailConfirmed { get; set; }

    [MaxLength(20)]
    public   string PhoneNumber { get; set; }

    [MaxLength(255)]
    public string FirstName { get; set; }

    [MaxLength(255)]
    public string LastName { get; set; }

    [ForeignKey("Role")]
    public Guid RoleID { get; set; }

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

    public virtual Role Role { get; set; }
    public virtual ICollection<Staff> Staffs { get; set; }
    public virtual ICollection<Member> Members { get; set; }
    public virtual ICollection<Supplier> Suppliers { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
    public virtual ICollection<Report> Reports { get; set; }
    public virtual ICollection<Policy> Policies { get; set; }
    public virtual ICollection<ProductStatus> ProductStatuses { get; set; }
    public virtual ICollection<SupplierStatus> SupplierStatuses { get; set; }
    public virtual ICollection<Wishlist> Wishlists { get; set; }
    public virtual ICollection<HistoryTransaction> HistoryTransactions { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; }
    public virtual ICollection<AccountRole> AccountRoles { get; set; }
 }

