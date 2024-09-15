using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace CameraServicesPlatform.BackEnd.Domain.Models
    {
        public class ProductVoucher
        {
            [Key]
            public Guid ProductVoucherID { get; set; }

            [Required]
            public Guid ProductID { get; set; }

            [ForeignKey(nameof(ProductID))]
            public Product Product { get; set; }

            [Required]
            public Guid VourcherID { get; set; }

            [ForeignKey(nameof(VourcherID))]
            public Vourcher Vourcher { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        }
    }
}
