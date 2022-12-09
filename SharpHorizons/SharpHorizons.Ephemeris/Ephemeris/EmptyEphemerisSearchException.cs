﻿namespace SharpHorizons.Ephemeris;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurred when attempting to search an empty <see cref="IEphemeris{TEntry}"/>.</summary>
public sealed class EmptyEphemerisSearchException : Exception
{
    /// <inheritdoc cref="EmptyEphemerisSearchException"/>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="EmptyEphemerisSearchException"/>.</param>
    public EmptyEphemerisSearchException(Exception? innerException = null) : base($"The {typeof(IEphemeris<IEphemerisEntry>).Name} is empty.", innerException) { }

    /// <inheritdoc cref="EmptyEphemerisSearchException"/>
    /// <param name="message">The message that describes the <see cref="EmptyEphemerisSearchException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="EmptyEphemerisSearchException"/>.</param>
    public EmptyEphemerisSearchException(string? message, Exception? innerException = null) : base(message, innerException) { }
}
