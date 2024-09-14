using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Staff
    {
        [Key]
        public Guid StaffID { get; set; }

        [Required]
        public Guid AccountID { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Account Account { get; set; }

        [Required]
        [MaxLength(255)]
        public string JobTitle { get; set; }

        [MaxLength(255)]
        public string Department { get; set; }

        [MaxLength(255)]
        public string StaffStatus { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool IsAdmin { get; set; }
    }
}
