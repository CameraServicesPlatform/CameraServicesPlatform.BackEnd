using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class DeliveryCompany
    {
        public Guid DeliveryCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string ContactInfo { get; set; }
    }

}
