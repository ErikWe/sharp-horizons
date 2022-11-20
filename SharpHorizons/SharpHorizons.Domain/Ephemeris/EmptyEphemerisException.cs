namespace SharpHorizons.Ephemeris;

using System;
using System.Collections.Generic;

/// <summary>Represents an error caused by attempting to access an <see cref="IEphemerisEntry"/> of an empty <see cref="IEphemeris{TEntry}"/>.</summary>
public sealed class EmptyEphemerisException : Exception
{
    /// <inheritdoc cref="EmptyEphemerisException"/>
    public EmptyEphemerisException() : base($"The {typeof(IEphemeris<IEphemerisEntry>).Name} is empty.") { }

    /// <inheritdoc cref="EmptyEphemerisException"/>
    /// <param name="message">The message that describes the error.</param>
    public EmptyEphemerisException(string? message) : base(message) { }

    /// <inheritdoc cref="EmptyEphemerisException"/>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current exception.</param>
    public EmptyEphemerisException(string? message, Exception? innerException) : base(message, innerException) { }
}
