using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class BankInformation
    {
        [Key]
        public Guid BankId { get; set; }

        public required string BankName { get; set; }

         public required string AccountNumber { get; set; }

        public required string AccountHolder { get; set; }

        // Foreign key to Member

        [ForeignKey(nameof(Account))]
        public string AccountID { get; set; }

        public Account Account { get; set; }
    }
}
