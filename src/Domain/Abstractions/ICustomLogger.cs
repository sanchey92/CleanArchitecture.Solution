namespace Domain.Abstractions;

/// <summary>
/// Interface for a custom logger.
/// </summary>
public interface ICustomLogger
{
    /// <summary>
    /// Log an informational message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    void LogInfo(string message);

    /// <summary>
    /// Log a warning message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    void LoggerWarn(string message);

    /// <summary>
    /// Log a debug message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    void LoggerDebug(string message);

    /// <summary>
    /// Log an error message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    void LoggerError(string message);
}