namespace SharpHorizons.Ephemeris;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurred when searching an <see cref="IEphemeris{TEntry}"/>, where the search boundaries failed to isolate an <see cref="IEphemerisEntry"/>.</summary>
public sealed class UnboundedEphemerisSearchException : Exception
{
    /// <inheritdoc cref="EmptyEphemerisSearchException"/>
    public UnboundedEphemerisSearchException() : this((Exception?)null) { }

    /// <inheritdoc cref="EmptyEphemerisSearchException"/>
    /// <param name="message">The message that describes the <see cref="UnboundedEphemerisSearchException"/>.</param>
    public UnboundedEphemerisSearchException(string? message) : this(message, null) { }

    /// <inheritdoc cref="UnboundedEphemerisSearchException"/>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnboundedEphemerisSearchException"/>.</param>
    public UnboundedEphemerisSearchException(Exception? innerException) : this($"The {typeof(IEphemeris<IEphemerisEntry>).Name} search was unbounded.", innerException) { }

    /// <inheritdoc cref="UnboundedEphemerisSearchException"/>
    /// <param name="message">The message that describes the <see cref="UnboundedEphemerisSearchException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnboundedEphemerisSearchException"/>.</param>
    public UnboundedEphemerisSearchException(string? message, Exception? innerException) : base(message, innerException) { }

    /// <summary>Represents an <see cref="Exception"/> that occurred when searching an <see cref="IEphemeris{TEntry}"/> for an <see cref="IEphemerisEntry"/> earlier than the earliest available <see cref="IEphemerisEntry"/>.</summary>
    public static UnboundedEphemerisSearchException Earliest() => Earliest(null);

    /// <inheritdoc cref="Earliest()"/>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnboundedEphemerisSearchException"/>.</param>
    public static UnboundedEphemerisSearchException Earliest(Exception? innerException) => new($"No {nameof(IEphemerisEntry)} in the {nameof(IEphemeris<IEphemerisEntry>)} describes an {nameof(IEpoch)} earlier than the specified {nameof(IEpoch)}.", innerException);

    /// <summary>Represents an <see cref="Exception"/> that occurred when searching an <see cref="IEphemeris{TEntry}"/> for an <see cref="IEphemerisEntry"/> later than the latest available <see cref="IEphemerisEntry"/>.</summary>
    public static UnboundedEphemerisSearchException Latest() => Latest(null);

    /// <inheritdoc cref="Latest()"/>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnboundedEphemerisSearchException"/>.</param>
    public static UnboundedEphemerisSearchException Latest(Exception? innerException) => new($"No {nameof(IEphemerisEntry)} in the {nameof(IEphemeris<IEphemerisEntry>)} describes an {nameof(IEpoch)} later than the specified {nameof(IEpoch)}.", innerException);
}
