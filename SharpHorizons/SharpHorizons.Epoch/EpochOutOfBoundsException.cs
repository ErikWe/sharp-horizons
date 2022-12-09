namespace SharpHorizons;

using SharpMeasures;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurred whwn an <see cref="IEpoch"/> attempts to represent an epoch outside of some supported boundary.</summary>
public sealed class EpochOutOfBoundsException : Exception
{
    /// <inheritdoc cref="EpochOutOfBoundsException"/>
    /// <param name="message">The message that describes the <see cref="EpochOutOfBoundsException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="EpochOutOfBoundsException"/>.</param>
    private EpochOutOfBoundsException(string? message = null, Exception? innerException = null) : base(message, innerException) { }

    /// <summary>Constructs a new instance of <see cref="EpochOutOfBoundsException"/> that occurred when attempting to add a <see cref="Time"/> <paramref name="difference"/> to an instance of <typeparamref name="TEpoch"/>.</summary>
    /// <typeparam name="TEpoch">The type of the <see cref="IEpoch"/> that the <see cref="EpochOutOfBoundsException"/> concerns.</typeparam>
    /// <param name="difference">The <see cref="Time"/> that was added from an instance of <typeparamref name="TEpoch"/>, which caused the <see cref="EpochOutOfBoundsException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="EpochOutOfBoundsException"/>.</param>
    public static EpochOutOfBoundsException FromAddition<TEpoch>(Time difference, Exception? innerException = null) where TEpoch : IEpoch => new($"Adding {difference.Days} days to the {typeof(TEpoch).Name} results in an epoch that cannot be represented by a {typeof(TEpoch).Name}.", innerException);
}
