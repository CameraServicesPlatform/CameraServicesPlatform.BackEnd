using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class WishlistResponse
    {
        public string WishlistID { get; set; }
        public string MemberID { get; set; }
        public string ProductID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
