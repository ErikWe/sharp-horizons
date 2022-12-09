namespace SharpHorizons.Query.Result.HTTP;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurred when trying to apply the <see cref="IHTTPQueryResult"/> of an unsuccessful HTTP request.</summary>
public sealed class UnsuccesfulHTTPRequestException : Exception
{
    /// <inheritdoc cref="UnsuccesfulHTTPRequestException"/>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsuccesfulHTTPRequestException"/>.</param>
    public UnsuccesfulHTTPRequestException(Exception? innerException = null) : base($"The {nameof(IHTTPQueryResult)} does not represent a successful HTTP query.", innerException) { }

    /// <inheritdoc cref="UnsuccesfulHTTPRequestException"/>
    /// <param name="message">The message that describes the <see cref="UnsuccesfulHTTPRequestException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsuccesfulHTTPRequestException"/>.</param>
    public UnsuccesfulHTTPRequestException(string? message, Exception? innerException = null) : base(message, innerException) { }
}
