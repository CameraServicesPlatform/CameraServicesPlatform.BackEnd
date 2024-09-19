using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request;
public class ForgotPasswordDTO
{
    public string Email { get; set; } = null!;
    public string? RecoveryCode { get; set; }
    public string? NewPassword { get; set; }
}
