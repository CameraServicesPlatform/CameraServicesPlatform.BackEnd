using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IHubService;
public interface IHubServices
{
    Task SendAsync(string method);
}
