using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models;
public class ProductStatus
{
    [Key]
    public Guid ProductStatusID { get; set; }
    public Guid SupplierID { get; set; }
    [ForeignKey(nameof(SupplierID))]
    public Supplier Supplier { get; set; }
    public Guid ProductID { get; set; }

    [ForeignKey(nameof(ProductID))]
    public Product Product { get; set; }

    public StatusType StatusType { get; set; }

    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    public DateTime? EndDate { get; set; }

    public string Reason { get; set; }

    public Guid HandledBy { get; set; }

    [ForeignKey(nameof(HandledBy))]
    public Account Account { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

