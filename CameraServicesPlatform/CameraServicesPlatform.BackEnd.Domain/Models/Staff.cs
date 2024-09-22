using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Staff
    {
        [Key]
        public Guid StaffID { get; set; }

        [ForeignKey(nameof(Account))]
        public string AccountID { get; set; }

        public Account Account { get; set; }



        public string JobTitle { get; set; }


        public string Department { get; set; }


        public string StaffStatus { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool IsAdmin { get; set; }
    }
}
