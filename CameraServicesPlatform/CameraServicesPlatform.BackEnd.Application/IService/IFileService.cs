using Microsoft.AspNetCore.Mvc;
//using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IFileService
    {
        public IActionResult GenerateExcelContent<T1, T2>(string fileName, IEnumerable<T1> dataList, IEnumerable<T2> dataList2, List<string> header, string sheetName, List<string> header2 = null, string sheetName2 = null);
        public IActionResult GenerateExcelSingleContent<T>(IEnumerable<T> dataList, string sheetName);
    }
}
