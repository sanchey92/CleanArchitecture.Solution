namespace Domain.Exceptions.Base;

/// <summary>
/// Represents an exception indicating that a requested resource was not found.
/// </summary>
public abstract class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class
    /// with the specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    protected NotFoundException(string message) : base(message)
    {
    }
}