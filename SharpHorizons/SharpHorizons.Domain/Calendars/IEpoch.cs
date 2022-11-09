namespace SharpHorizons.Calendars;

using System;

/// <summary>Represents an epoch, an instant in time.</summary>
public interface IEpoch
{
    /// <summary>Converts <see langword="this"/> to the <typeparamref name="TEpoch"/> representing the same epoch.</summary>
    /// <typeparam name="TEpoch"><see langword="this"/> is converted to an <see cref="IEpoch"/> of this type, representing the same epoch.</typeparam>
    public abstract TEpoch ToEpoch<TEpoch>() where TEpoch : IEpoch<TEpoch>;

    /// <summary>Converts <see langword="this"/> to the <see cref="JulianDay"/> representing the same epoch.</summary>
    public abstract JulianDay ToJulianDay();

    /// <summary>Converts <see langword="this"/> to the <see cref="DateTime"/> representing the same epoch.</summary>
    public abstract DateTime ToDateTime();
}

/// <inheritdoc/>
public interface IEpoch<TSelf> : IEpoch where TSelf : IEpoch<TSelf>
{
    /// <summary>Constructs the <typeparamref name="TSelf"/> representing the same epoch as <paramref name="epoch"/>.</summary>
    /// <typeparam name="TEpoch">An <see cref="IEpoch"/> of this type is used to construct a <typeparamref name="TSelf"/> representing the same epoch.</typeparam>
    /// <param name="epoch">The constructed <typeparamref name="TSelf"/> represents the same epoch as this <typeparamref name="TEpoch"/>.</param>
    public abstract static TSelf FromEpoch<TEpoch>(TEpoch epoch) where TEpoch : IEpoch<TEpoch>;

    /// <summary>Constructs the <typeparamref name="TSelf"/> representing the same epoch as <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <typeparamref name="TSelf"/> represents the same epoch as this <see cref="JulianDay"/>.</param>
    public abstract static TSelf FromJulianDay(JulianDay julianDay);

    /// <summary>Constructs the <typeparamref name="TSelf"/> representing the same epoch as <paramref name="dateTime"/>.</summary>
    /// <param name="dateTime">The constructed <typeparamref name="TSelf"/> represents the same epoch as this <see cref="DateTime"/>.</param>
    public abstract static TSelf FromDateTime(DateTime dateTime);
}