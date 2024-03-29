﻿namespace SharpHorizons.Query.Origin;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurred when requesting the coordinate of an <see cref="IOrigin"/> that does not apply a coordinate.</summary>
public sealed class OriginNotUsingCoordinateException : Exception
{
    /// <inheritdoc cref="OriginNotUsingCoordinateException"/>
    public OriginNotUsingCoordinateException() : this((Exception?)null) { }

    /// <inheritdoc cref="OriginNotUsingCoordinateException"/>
    /// <param name="message">The message that describes the <see cref="OriginNotUsingCoordinateException"/>.</param>
    public OriginNotUsingCoordinateException(string? message) : this(message, null) { }

    /// <inheritdoc cref="OriginNotUsingCoordinateException"/>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="OriginNotUsingCoordinateException"/>.</param>
    public OriginNotUsingCoordinateException(Exception? innerException) : this($"The {nameof(IOrigin)} does not apply a coordinate.", innerException) { }

    /// <inheritdoc cref="OriginNotUsingCoordinateException"/>
    /// <param name="message">The message that describes the <see cref="OriginNotUsingCoordinateException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="OriginNotUsingCoordinateException"/>.</param>
    public OriginNotUsingCoordinateException(string? message, Exception? innerException) : base(message, innerException) { }
}
