using CameraServicesPlatform.BackEnd.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class User : IdentityUser
{
    [Key]
public Guid UserId { get; set; }

[MaxLength(255)]
public override string UserName { get; set; }

[MaxLength(255)]
public override string Email { get; set; }

public bool EmailConfirmed { get; set; }

[MaxLength(20)]
public override string PhoneNumber { get; set; }

[MaxLength(255)]
public string FirstName { get; set; }

[MaxLength(255)]
public string LastName { get; set; }

public Guid? RoleId { get; set; }

  
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

public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

public virtual ICollection<Shop> Shops { get; set; }
public virtual ICollection<Payment> Payments { get; set; }
public virtual ICollection<Order> Orders { get; set; }
public virtual ICollection<Rating> Ratings { get; set; }
public virtual ICollection<Report> Reports { get; set; }
    }

