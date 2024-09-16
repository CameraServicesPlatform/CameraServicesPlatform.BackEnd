using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class FileService : GenericBackendService, IFileService
    {
        private AppActionResult _result;

        public FileService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _result = new();
        }

        public IActionResult GenerateExcelContent<T1, T2>(string fileName, IEnumerable<T1> dataList, IEnumerable<T2> dataList2, List<string> header, string sheetName, List<string> header2 = null, string sheetName2 = null)
        {
            throw new NotImplementedException();
        }

        public IActionResult GenerateExcelSingleContent<T>(IEnumerable<T> dataList, string sheetName)
        {
            throw new NotImplementedException();
        }
    }
}
