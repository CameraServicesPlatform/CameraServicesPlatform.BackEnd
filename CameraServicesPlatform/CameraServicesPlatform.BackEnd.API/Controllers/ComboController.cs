using CameraServicesPlatform.BackEnd.Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace CameraServicesPlatform.BackEnd.API.Controllers
{
    [Route("combo")]
    [ApiController]
    public class ComboController : ControllerBase
    {
        private readonly IComboService _comboService;

        public ComboController(
        IComboService comboService
        )
        {
            _comboService = comboService;
        }
}
}
