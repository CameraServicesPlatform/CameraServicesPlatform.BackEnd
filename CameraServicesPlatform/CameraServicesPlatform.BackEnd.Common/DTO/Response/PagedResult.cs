using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class PagedResult<T> where T : class
    {
        public List<T>? Items { get; set; }
        public int TotalPages { get; set; }
    }
}
