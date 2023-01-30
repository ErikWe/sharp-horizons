namespace SharpHorizons;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;

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
public interface IEpoch<out TSelf> : IEpoch where TSelf : IEpoch<TSelf>
{
    /// <summary>Constructs an instance of <typeparamref name="TSelf"/>, representing the same epoch as <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <typeparamref name="TSelf"/> represents the same epoch as this <see cref="JulianDay"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    [SuppressMessage("Design", "CA1000: Do not declare static members on generic types", Justification = "Implementing type is not necessarily generic.")]
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
}
