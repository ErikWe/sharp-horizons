namespace SharpHorizons.Ephemeris;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurred when searching an <see cref="IEphemeris{TEntry}"/>, where the search boundaries failed to isolate an <see cref="IEphemerisEntry"/>.</summary>
public sealed class UnboundedEphemerisSearchException : Exception
{
    /// <inheritdoc cref="UnboundedEphemerisSearchException"/>
    /// <param name="message">The message that describes the <see cref="UnboundedEphemerisSearchException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnboundedEphemerisSearchException"/>.</param>
    private UnboundedEphemerisSearchException(string message, Exception? innerException = null) : base(message, innerException) { }

    /// <summary>Represents an <see cref="Exception"/> that occurred when searching an <see cref="IEphemeris{TEntry}"/> for an <see cref="IEphemerisEntry"/> earlier than the earliest available <see cref="IEphemerisEntry"/>.</summary>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnboundedEphemerisSearchException"/>.</param>
    public static UnboundedEphemerisSearchException Earliest(Exception? innerException = null) => new($"No {nameof(IEphemerisEntry)} in the {nameof(IEphemeris<IEphemerisEntry>)} describes an {nameof(IEpoch)} earlier than the specified {nameof(IEpoch)}.", innerException);

    /// <summary>Represents an <see cref="Exception"/> that occurred when searching an <see cref="IEphemeris{TEntry}"/> for an <see cref="IEphemerisEntry"/> later than the latest available <see cref="IEphemerisEntry"/>.</summary>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnboundedEphemerisSearchException"/>.</param>
    public static UnboundedEphemerisSearchException Latest(Exception? innerException = null) => new($"No {nameof(IEphemerisEntry)} in the {nameof(IEphemeris<IEphemerisEntry>)} describes an {nameof(IEpoch)} later than the specified {nameof(IEpoch)}.", innerException);
}
