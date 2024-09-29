﻿using CameraServicesPlatform.BackEnd.Domain.Enum.Status;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class ProductResponseDto
    {
        public string SerialNumber { get; set; }

         public Guid SupplierID { get; set; }

        public Guid CategoryID { get; set; }
 

        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public double Price { get; set; }


        public string? Brand { get; set; }

        public ProductStatusEnum Status { get; set; }

    }
}
