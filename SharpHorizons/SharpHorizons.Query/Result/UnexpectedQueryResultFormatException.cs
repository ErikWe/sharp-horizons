namespace SharpHorizons.Query.Result;

using System;

/// <summary>Represents an <see cref="Exception"/> caused by the result of a query being of an unexpected format.</summary>
public class UnexpectedQueryResultFormatException : Exception
{
    /// <inheritdoc cref="UnexpectedQueryResultFormatException"/>
    public UnexpectedQueryResultFormatException(Exception? innerException = null) : base($"The result of the query was of an unexpected format.", innerException) { }

    /// <inheritdoc cref="UnexpectedQueryResultFormatException"/>
    /// <param name="message">The message that describes the <see cref="UnexpectedQueryResultFormatException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnexpectedQueryResultFormatException"/>.</param>
    public UnexpectedQueryResultFormatException(string? message, Exception? innerException = null) : base(message, innerException) { }
}
