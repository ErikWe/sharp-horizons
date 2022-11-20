namespace SharpHorizons.Query.Result.HTTP;

using System;

/// <summary>Represents an error caused by trying to apply the <see cref="IHTTPQueryResult"/> of an unsuccessful HTTP request.</summary>
public sealed class UnsuccesfulHTTPRequestException : Exception
{
    /// <inheritdoc cref="UnsuccesfulHTTPRequestException"/>
    public UnsuccesfulHTTPRequestException() : base($"The {typeof(IHTTPQueryResult).Name} does not represent a successful HTTP query.") { }

    /// <inheritdoc cref="UnsuccesfulHTTPRequestException"/>
    /// <param name="message">The message that describes the error.</param>
    public UnsuccesfulHTTPRequestException(string? message) : base(message) { }

    /// <inheritdoc cref="UnsuccesfulHTTPRequestException"/>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current exception.</param>
    public UnsuccesfulHTTPRequestException(string? message, Exception? innerException) : base(message, innerException) { }
}
