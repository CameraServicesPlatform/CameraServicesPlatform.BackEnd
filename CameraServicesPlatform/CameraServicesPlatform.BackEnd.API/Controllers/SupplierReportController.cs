using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("supplierReport")]
    [ApiController]
    public class SupplierReportController : ControllerBase
    {
        private readonly ISupplierReportService _supplierReportService;

        public SupplierReportController(ISupplierReportService supplierReportService)
        {
            _supplierReportService = supplierReportService;
        }

    }
}
