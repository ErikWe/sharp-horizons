namespace SharpHorizons;

using SharpMeasures;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurs whwn an <see cref="IEpoch"/> attempts to represent an epoch outside of some supported boundary.</summary>
public sealed class EpochOutOfBoundsException : Exception
{
    /// <inheritdoc cref="EpochOutOfBoundsException"/>
    /// <param name="message">The message that describes the <see cref="EpochOutOfBoundsException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="EpochOutOfBoundsException"/>.</param>
    private EpochOutOfBoundsException(string? message = null, Exception? innerException = null) : base(message, innerException) { }

    /// <summary>Constructs a new instance of <see cref="EpochOutOfBoundsException"/> that occurred when attempting to convert an instance of <typeparamref name="TEpoch"/> to a <see cref="JulianDay"/>.</summary>
    /// <typeparam name="TEpoch">The type of the <see cref="IEpoch"/> that the <see cref="EpochOutOfBoundsException"/> concerns.</typeparam>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="EpochOutOfBoundsException"/>.</param>
    public static EpochOutOfBoundsException ToJulianDay<TEpoch>(Exception? innerException = null) where TEpoch : IEpoch => new($"The {typeof(TEpoch).Name} could not be represented as a {nameof(JulianDay)}.", innerException);

    /// <summary>Constructs a new instance of <see cref="EpochOutOfBoundsException"/> that occurred when attempting to add a <see cref="Time"/> <paramref name="difference"/> to an instance of <typeparamref name="TEpoch"/>.</summary>
    /// <typeparam name="TEpoch">The type of the <see cref="IEpoch"/> that the <see cref="EpochOutOfBoundsException"/> concerns.</typeparam>
    /// <param name="difference">The <see cref="Time"/> that was added to an instance of <typeparamref name="TEpoch"/>, causing the <see cref="EpochOutOfBoundsException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="EpochOutOfBoundsException"/>.</param>
    public static EpochOutOfBoundsException FromAddition<TEpoch>(Time difference, Exception? innerException = null) where TEpoch : IEpoch => new($"Adding {difference.Days} days to the {typeof(TEpoch).Name} results in an epoch that cannot be represented by a {typeof(TEpoch).Name}.", innerException);

    /// <summary>Constructs a new instance of <see cref="EpochOutOfBoundsException"/> that occurred when attempting to subtract a <see cref="Time"/> <paramref name="difference"/> from an instance of <typeparamref name="TEpoch"/>.</summary>
    /// <typeparam name="TEpoch">The type of the <see cref="IEpoch"/> that the <see cref="EpochOutOfBoundsException"/> concerns.</typeparam>
    /// <param name="difference">The <see cref="Time"/> that was subtracted from an instance of <typeparamref name="TEpoch"/>, causing the <see cref="EpochOutOfBoundsException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="EpochOutOfBoundsException"/>.</param>
    public static EpochOutOfBoundsException FromSubtraction<TEpoch>(Time difference, Exception? innerException = null) where TEpoch : IEpoch => new($"Adding {difference.Days} days to the {typeof(TEpoch).Name} results in an epoch that cannot be represented by a {typeof(TEpoch).Name}.", innerException);
}
