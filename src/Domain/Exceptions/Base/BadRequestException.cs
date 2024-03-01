namespace Domain.Exceptions.Base;

/// <summary>
/// Represents an exception indicating a client's request is malformed or invalid.
/// </summary>
public abstract class BadRequestException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class
    /// with the specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    protected BadRequestException(string message) : base(message)
    {
    }
}
