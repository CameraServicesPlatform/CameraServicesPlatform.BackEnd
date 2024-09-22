using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class BankInformation
    {
        [Key]
        public Guid BankId { get; set; }


        public string BankName { get; set; }

        [MaxLength(100)]
        public string AccountNumber { get; set; }


        public string AccountHolder { get; set; }

        // Foreign key to Member
        [ForeignKey("Member")]
        public Guid MemberId { get; set; }
        public virtual Member Member { get; set; }
    }
}
