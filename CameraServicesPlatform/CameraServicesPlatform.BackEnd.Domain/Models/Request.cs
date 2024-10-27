using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Request
    {
        [Key]
        public Guid SupplierRequestID { get; set; }

        public string? AccountID { get; set; }

        public Guid RoleRequestID { get; set; }

        public RequestStatus RequestStatus { get; set; }

        public DateTime RequestDate { get; set; }

        public Guid? ReviewedBy { get; set; }

        public DateTime? ReviewDate { get; set; }

        public string ReviewNotes { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Account? Account { get; set; }

        [ForeignKey(nameof(ReviewedBy))]
        public bool IsDisable { get; set; }
    }
}
