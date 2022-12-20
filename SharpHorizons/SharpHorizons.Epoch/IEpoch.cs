namespace SharpHorizons;

using NodaTime;

using SharpMeasures;

using System;

/// <summary>Represents an epoch, an instant in time.</summary>
public interface IEpoch : IComparable<IEpoch>
{
    /// <summary>The <see cref="NodaTime.Instant"/> represented by the <see cref="IEpoch"/>.</summary>
    public abstract Instant Instant { get; }

    /// <summary>Converts the <see cref="IEpoch"/> to an instance of <see cref="JulianDay"/> representing the same epoch.</summary>
    public abstract JulianDay ToJulianDay();

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }.</summary>
    /// <param name="initial">The initial <see cref="IEpoch"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract Time Difference(IEpoch initial);

    /// <summary>Computes the <see cref="IEpoch"/> representing { <see langword="this"/> + <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> <see cref="IEpoch"/> and the resulting <see cref="IEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public abstract IEpoch Add(Time difference);
}

/// <inheritdoc cref="IEpoch"/>
/// <typeparam name="TSelf">The self-type.</typeparam>
public interface IEpoch<TSelf> : IEpoch where TSelf : IEpoch<TSelf>
{
    /// <summary>Constructs an instance of <typeparamref name="TSelf"/>, representing the same epoch as <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <typeparamref name="TSelf"/> represents the same epoch as this <see cref="JulianDay"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static abstract TSelf FromJulianDay(JulianDay julianDay);

    /// <summary>Computes the <typeparamref name="TSelf"/> representing { <paramref name="initial"/> + <paramref name="difference"/> }.</summary>
    /// <param name="initial">The <typeparamref name="TSelf"/> representing the initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between the <paramref name="initial"/> <typeparamref name="TSelf"/> and the resulting <typeparamref name="TSelf"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static abstract TSelf operator +(TSelf initial, Time difference);

    /// <summary>Computes the <typeparamref name="TSelf"/> representing { <paramref name="initial"/> - <paramref name="difference"/> }.</summary>
    /// <param name="initial">The <typeparamref name="TSelf"/> representing the initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between the <paramref name="initial"/> <typeparamref name="TSelf"/> and the resulting <typeparamref name="TSelf"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static abstract TSelf operator -(TSelf initial, Time difference);
}
