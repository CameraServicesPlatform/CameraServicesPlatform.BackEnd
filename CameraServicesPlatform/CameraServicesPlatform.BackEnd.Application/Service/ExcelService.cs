using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.Utils;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Text;


namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class ExcelService : GenericBackendService, IExcelService
    {

        private readonly BackEndLogger _logger;

        public ExcelService(BackEndLogger logger, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _logger = logger;
        }

        public async Task<string> CheckHeader(IFormFile file, List<string> headerTemplate, int sheetNumber = 0)
        {
            if (file == null || file.Length == 0)
            {
                return "Không tìm thấy file";
            }

            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0;

                    using (ExcelPackage package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetNumber]; // Assuming data is in the first sheet

                        int colCount = worksheet.Columns.Count();
                        if (colCount != headerTemplate.Count && worksheet.Cells[1, colCount].Value != null)
                        {
                            return "Số lượng cột không đúng.";
                        }
                        StringBuilder sb = new StringBuilder();
                        sb.Append("Tên cột sai: ");
                        bool containsError = false;
                        for (int col = 1; col <= Math.Min(5, worksheet.Columns.Count()); col++) // Assuming header is in the first row
                        {
                            if (!worksheet.Cells[1, col].Value.Equals(headerTemplate[col - 1]))
                            {
                                if (!containsError) containsError = true;
                                sb.Append($"{worksheet.Cells[1, col].Value}(Tên đúng: {headerTemplate[col - 1]}), ");
                            }
                        }
                        if (containsError)
                        {
                            return sb.Remove(sb.Length - 2, 2).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return string.Empty;
        }

        public void SetBorders(ExcelWorksheet worksheet, ExcelRange range, ExcelBorderStyle outerBorderStyle, ExcelBorderStyle innerBorderStyle)
        {
            // Set the outer borders
            range.Style.Border.Top.Style = outerBorderStyle;
            range.Style.Border.Left.Style = outerBorderStyle;
            range.Style.Border.Right.Style = outerBorderStyle;
            range.Style.Border.Bottom.Style = outerBorderStyle;

            // Set the inner borders for each cell in the range
            int startRow = range.Start.Row;
            int endRow = range.End.Row;
            int startColumn = range.Start.Column;
            int endColumn = range.End.Column;

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startColumn; col <= endColumn; col++)
                {
                    var cell = worksheet.Cells[row, col];

                    if (row != startRow)
                    {
                        cell.Style.Border.Top.Style = innerBorderStyle;
                    }
                    if (row != endRow)
                    {
                        cell.Style.Border.Bottom.Style = innerBorderStyle;
                    }
                    if (col != startColumn)
                    {
                        cell.Style.Border.Left.Style = innerBorderStyle;
                    }
                    if (col != endColumn)
                    {
                        cell.Style.Border.Right.Style = innerBorderStyle;
                    }
                }
            }
        }
    }
}
