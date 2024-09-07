using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class Staff
{
    [Key]
    public Guid StaffID { get; set; }

    public Guid AccountID { get; set; }

    [ForeignKey(nameof(AccountID))]

    [MaxLength(255)]
    public string JobTitle { get; set; }

    [MaxLength(255)]
    public string Department { get; set; }

    public string StaffStatus { get; set; }

    public DateTime HireDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public bool IsAdmin { get; set; }

    public Account Account { get; set; }


}