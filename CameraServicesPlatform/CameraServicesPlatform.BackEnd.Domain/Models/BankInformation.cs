using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class BankInformation
    {
        [Key]
        public Guid BankId { get; set; }

        [MaxLength(255)]
        public string BankName { get; set; }

        [MaxLength(100)]
        public string AccountNumber { get; set; }

        [MaxLength(255)]
        public string AccountHolder { get; set; }

        // Foreign key to Member
        [ForeignKey("Member")]
        public Guid MemberId { get; set; }
        public virtual Member Member { get; set; }
    }
}
