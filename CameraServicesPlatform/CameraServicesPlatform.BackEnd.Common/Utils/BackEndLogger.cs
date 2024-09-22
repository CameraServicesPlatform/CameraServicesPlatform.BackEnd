using Microsoft.Extensions.Logging;

namespace CameraServicesPlatform.BackEnd.Common.Utils;
public class BackEndLogger
{
    public ILogger<BackEndLogger> _logger;

    public BackEndLogger(ILogger<BackEndLogger> logger)
    {
        _logger = logger;
    }

    public void LogError<T>(string message, T className) where T : class
    {
        _logger.LogError($"Exception of type {typeof(T)} occurred: {message}");
    }

    public void LogWarning<T>(string message, T className) where T : class
    {
        _logger.LogWarning($"Warning of type {typeof(T)} occurred: {message}");
    }

    public void LogInformation<T>(string message, T className) where T : class
    {
        _logger.LogInformation($"Information of type {typeof(T)} occurred: {message}");
    }
}