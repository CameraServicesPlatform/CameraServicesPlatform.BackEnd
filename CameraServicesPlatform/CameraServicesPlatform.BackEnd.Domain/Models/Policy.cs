using CameraServicesPlatform.BackEnd.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Policy
    {
        [Key]
        public Guid PolicyID { get; set; }

        public PolicyType PolicyType { get; set; }

        public string PolicyContent { get; set; }
        // doi tuong ap dung chinh sach
        public ApplicableObject ApplicableObject { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime Value { get; set; }

        public Guid? StaffID { get; set; }

        [ForeignKey(nameof(StaffID))]
        public Staff? Staff { get; set; }
    }
}
