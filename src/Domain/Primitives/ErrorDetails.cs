using System.Text.Json;

namespace Domain.Primitives;

/// <summary>
/// Represents details of an error response, including the HTTP status code and an optional error message.
/// </summary>
public sealed class ErrorDetails
{
    /// <summary>
    /// Gets or initializes the HTTP status code associated with the error.
    /// </summary>
    public int StatusCode { get; init; }

    /// <summary>
    /// Gets or initializes the optional error message.
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    /// Converts the instance to its JSON representation.
    /// </summary>
    /// <returns>A JSON-formatted string representing the error details.</returns>
    public override string ToString() => JsonSerializer.Serialize(this);
}