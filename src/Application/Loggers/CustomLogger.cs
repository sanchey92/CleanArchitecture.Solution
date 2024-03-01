using Domain.Abstractions;
using NLog;

namespace Application.Loggers;

/// <summary>
/// Implementation of <see cref="ICustomLogger"/> using NLog.
/// </summary>
public class CustomLogger : ICustomLogger
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public CustomLogger()
    {
    }

    public void LogInfo(string message) => _logger.Info(message);

    public void LoggerWarn(string message) => _logger.Warn(message);

    public void LoggerDebug(string message) => _logger.Debug(message);

    public void LoggerError(string message) => _logger.Error(message);
}