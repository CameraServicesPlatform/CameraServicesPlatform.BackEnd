using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request
{
    public class WishlistRequestDTO
    {
        public Guid WishlistID { get; set; }
        public Guid AccountID { get; set; }
        public Guid ProductID { get; set; }
    }
}
