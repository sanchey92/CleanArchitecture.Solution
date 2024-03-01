namespace Domain.Exceptions.Base;

/// <summary>
/// Represents an exception thrown for one or more validation errors during API request processing.
/// </summary>
public sealed class ValidationApiException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationApiException"/> class.
    /// </summary>
    /// <param name="errors">The dictionary of validation errors.</param>
    public ValidationApiException(IReadOnlyDictionary<string, string[]> errors)
        : base("One or more validations errors occurred")
        => Errors = errors;

    /// <summary>
    /// Gets the dictionary of validation errors associated with the exception.
    /// </summary>
    public IReadOnlyDictionary<string, string[]> Errors { get; }
}
