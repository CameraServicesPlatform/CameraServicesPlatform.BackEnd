using CameraServicesPlatform.BackEnd.Application.IHubService;
using CameraServicesPlatform.BackEnd.Infrastructure.ServerHub;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Infrastructure.HubServices;

public class HubServices : IHubServices
{
    private readonly IHubContext<NotificationHub> _signalRHub;

    public HubServices(IHubContext<NotificationHub> signalRHub)
    {
        _signalRHub = signalRHub;
    }

    public async Task SendAsync(string method)
    {
        await _signalRHub.Clients.All.SendAsync(method);
    }
}