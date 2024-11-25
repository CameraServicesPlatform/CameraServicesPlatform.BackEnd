using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class CountProductDto
    {
        public int ProductId { get; set; } 
        public int Serial { get; set; }
        public string ProductName { get; set; }
        public int countRent {  get; set; }
        public double ProductPriceFirst { get; set; }// giá ban đầu sản phẩm

    }
}
