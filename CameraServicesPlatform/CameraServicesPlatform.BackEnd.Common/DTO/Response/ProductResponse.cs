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
    public class ProductResponse
    {
        Product product;
        List<ProductImage> listImage = new List<ProductImage>();

        public ProductResponse(Product product, List<ProductImage> listImage)
        {
            this.product = product;
            this.listImage = listImage;
        }
    }
}
