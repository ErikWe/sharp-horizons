namespace SharpHorizons;

using SharpMeasures;

using System;

/// <summary>Represents an epoch, an instant in time.</summary>
public interface IEpoch : IComparable<IEpoch>
{
    /// <summary>Converts the <see cref="IEpoch"/> to an instance of <see cref="JulianDay"/> representing the same epoch.</summary>
    /// <exception cref="EpochOutOfBoundsException"/>
    public abstract JulianDay ToJulianDay();

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if <see langword="this"/> <see cref="IEpoch"/> represents a later epoch than the <paramref name="initial"/> <see cref="IEpoch"/>.</summary>
    /// <param name="initial">The <see cref="IEpoch"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract Time Difference(IEpoch initial);
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

    /// <summary>Computes the <typeparamref name="TSelf"/> representing { <see langword="this"/> + <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> <typeparamref name="TSelf"/> and the resulting <typeparamref name="TSelf"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public abstract TSelf Add(Time difference);

    /// <summary>Computes the <typeparamref name="TSelf"/> representing { <see langword="this"/> - <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> <typeparamref name="TSelf"/> and the resulting <typeparamref name="TSelf"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public abstract TSelf Subtract(Time difference);

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

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if the <paramref name="final"/> <typeparamref name="TSelf"/> represents a later epoch than the <paramref name="initial"/> <typeparamref name="TSelf"/>.</summary>
    /// <param name="final">The <typeparamref name="TSelf"/> representing the final epoch.</param>
    /// <param name="initial">The <typeparamref name="TSelf"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public static abstract Time operator -(TSelf final, TSelf initial);
}
