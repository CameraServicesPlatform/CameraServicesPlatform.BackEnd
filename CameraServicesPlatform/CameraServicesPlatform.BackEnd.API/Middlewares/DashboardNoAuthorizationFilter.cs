using Hangfire.Dashboard;

namespace CameraServicesPlatform.BackEnd.API.Middlewares;

public class DashboardNoAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        return true;
    }
}