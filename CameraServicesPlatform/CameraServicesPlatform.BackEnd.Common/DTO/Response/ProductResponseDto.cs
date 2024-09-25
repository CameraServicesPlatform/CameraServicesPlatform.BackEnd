using CameraServicesPlatform.BackEnd.Domain.Enum.Status;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ProductResponseDto
    {
        public string SerialNumber { get; set; }

        public string SupplierID { get; set; }

        public string CategoryID { get; set; }

        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public double Price { get; set; }


        public string? Brand { get; set; }


        public ProductStatusEnum Status { get; set; }


    }
}
