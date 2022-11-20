namespace SharpHorizons.Ephemeris;

using SharpHorizons.Epoch;

using System;

/// <summary>Represents an error caused by attempting to access an unbounded <see cref="IEphemerisEntry"/> of an <see cref="IEphemeris{TEntry}"/>.</summary>
public sealed class UnboundedEphemerisEntryException : Exception
{
    /// <inheritdoc cref="UnboundedEphemerisEntryException"/>
    /// <param name="message">The message that describes the error.</param>
    public UnboundedEphemerisEntryException(string? message) : base(message) { }

    /// <inheritdoc cref="UnboundedEphemerisEntryException"/>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current exception.</param>
    public UnboundedEphemerisEntryException(string? message, Exception? innerException) : base(message, innerException) { }

    /// <summary>Represents an error caused by attempting to access an <see cref="IEphemerisEntry"/> earlier than the earliest <see cref="IEphemerisEntry"/> of an <see cref="IEphemeris{TEntry}"/>.</summary>
    public static UnboundedEphemerisEntryException Earliest => new($"No {typeof(IEphemerisEntry).Name} in the {typeof(IEphemeris<IEphemerisEntry>).Name} describes an {typeof(IEpoch).Name} earlier than the requested {typeof(IEpoch).Name}.");

    /// <summary>Represents an error caused by attempting to access an <see cref="IEphemerisEntry"/> later than the latest <see cref="IEphemerisEntry"/> of an <see cref="IEphemeris{TEntry}"/>.</summary>
    public static UnboundedEphemerisEntryException Latest => new($"No {typeof(IEphemerisEntry).Name} in the {typeof(IEphemeris<IEphemerisEntry>).Name} describes an {typeof(IEpoch).Name} later than the requested {typeof(IEpoch).Name}.");
}
