using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SupplierRequest
{
    [Key]
    public Guid SupplierRequestID { get; set; }


    public Guid SupplierID { get; set; }

    public RequestType RequestType { get; set; }


    public string RequestDetails { get; set; }


    public DateTime RequestDate { get; set; }

    public RequestStatus RequestStatus { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(SupplierID))]
    public Supplier Supplier { get; set; }
}
