namespace SharpHorizons.Query.Result;

using System;

/// <summary>Represents an error caused by the result of a query being of an unexpected format.</summary>
public class UnexpectedQueryResultFormatException : Exception
{
    /// <inheritdoc cref="UnexpectedQueryResultFormatException"/>
    public UnexpectedQueryResultFormatException() : base($"The result of the query was of an unexpected format.") { }

    /// <inheritdoc cref="UnexpectedQueryResultFormatException"/>
    /// <param name="message">The message that describes the error.</param>
    public UnexpectedQueryResultFormatException(string? message) : base(message) { }

    /// <inheritdoc cref="UnexpectedQueryResultFormatException"/>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current exception.</param>
    public UnexpectedQueryResultFormatException(string? message, Exception? innerException) : base(message, innerException) { }
}
