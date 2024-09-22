using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IExcelService
    {
        public Task<string> CheckHeader(IFormFile file, List<string> headerTemplate, int sheetNumber = 0);
        public void SetBorders(ExcelWorksheet worksheet, ExcelRange range, ExcelBorderStyle outerBorderStyle, ExcelBorderStyle innerBorderStyle);
    }
}