﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request;
public class LoginRequestDTO
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}