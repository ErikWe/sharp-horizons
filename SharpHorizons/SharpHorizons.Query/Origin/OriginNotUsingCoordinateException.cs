namespace SharpHorizons.Query.Origin;

using System;

/// <summary>Represents an error caused by requesting the coordinate of an <see cref="IOrigin"/> that does not apply a coordinate.</summary>
public sealed class OriginNotUsingCoordinateException : Exception
{
    /// <inheritdoc cref="OriginNotUsingCoordinateException"/>
    public OriginNotUsingCoordinateException() : base($"The {typeof(IOrigin).Name} does not apply a coordinate.") { }

    /// <inheritdoc cref="OriginNotUsingCoordinateException"/>
    /// <param name="message">The message that describes the error.</param>
    public OriginNotUsingCoordinateException(string? message) : base(message) { }

    /// <inheritdoc cref="OriginNotUsingCoordinateException"/>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current exception.</param>
    public OriginNotUsingCoordinateException(string? message, Exception? innerException) : base(message, innerException) { }
}
