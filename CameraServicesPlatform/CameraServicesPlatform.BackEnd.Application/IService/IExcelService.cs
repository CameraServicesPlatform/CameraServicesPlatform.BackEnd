using Microsoft.AspNetCore.Http;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IExcelService
    {
        public Task<string> CheckHeader(IFormFile file, List<string> headerTemplate, int sheetNumber = 0);
        public void SetBorders(ExcelWorksheet worksheet, ExcelRange range, ExcelBorderStyle outerBorderStyle, ExcelBorderStyle innerBorderStyle);
    }
}