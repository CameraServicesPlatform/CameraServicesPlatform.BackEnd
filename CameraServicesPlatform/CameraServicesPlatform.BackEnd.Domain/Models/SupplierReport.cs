using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class SupplierReport
    {
        [Key]
        public Guid SupplierReportID { get; set; }

        public Guid SupplierID { get; set; }

        [ForeignKey(nameof(SupplierID))]
        public Supplier? Supplier { get; set; }

        public StatusType StatusType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Reason { get; set; }

        public string? AccountID { get; set; }  

        [ForeignKey(nameof(AccountID))]
        public Account? Account { get; set; }

        public Guid StaffID { get; set; }  

        [ForeignKey(nameof(StaffID))]
        public Staff Staff { get; set; }
    }
}
