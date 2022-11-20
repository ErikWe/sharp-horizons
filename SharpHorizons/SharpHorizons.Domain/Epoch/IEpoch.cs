namespace SharpHorizons.Epoch;

using System;

/// <summary>Represents an epoch, an instant in time.</summary>
public interface IEpoch
{
    /// <summary>Converts <see langword="this"/> to the <typeparamref name="TEpoch"/> representing the same epoch.</summary>
    /// <typeparam name="TEpoch"><see langword="this"/> is converted to an <see cref="IEpoch"/> of this type, representing the same epoch.</typeparam>
    public virtual TEpoch ToEpoch<TEpoch>() where TEpoch : IEpoch<TEpoch> => TEpoch.FromJulianDay(ToJulianDay());

    /// <summary>Converts <see langword="this"/> to the <see cref="JulianDay"/> representing the same epoch.</summary>
    public abstract JulianDay ToJulianDay();

    /// <summary>Converts <see langword="this"/> to the <see cref="DateTime"/> representing the same epoch.</summary>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public virtual DateTime ToDateTime() => ToJulianDay().ToDateTime();
}

/// <inheritdoc/>
public interface IEpoch<TSelf> : IEpoch where TSelf : IEpoch<TSelf>
{
    /// <summary>Constructs the <typeparamref name="TSelf"/> representing the same epoch as <paramref name="epoch"/>.</summary>
    /// <typeparam name="TEpoch">An <see cref="IEpoch"/> of this type is used to construct a <typeparamref name="TSelf"/> representing the same epoch.</typeparam>
    /// <param name="epoch">The constructed <typeparamref name="TSelf"/> represents the same epoch as this <typeparamref name="TEpoch"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public virtual static TSelf FromEpoch<TEpoch>(TEpoch epoch) where TEpoch : IEpoch<TEpoch>
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return TSelf.FromJulianDay(epoch.ToJulianDay());
    }

    /// <summary>Constructs the <typeparamref name="TSelf"/> representing the same epoch as <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <typeparamref name="TSelf"/> represents the same epoch as this <see cref="JulianDay"/>.</param>
    public abstract static TSelf FromJulianDay(JulianDay julianDay);

    /// <summary>Constructs the <typeparamref name="TSelf"/> representing the same epoch as <paramref name="dateTime"/>.</summary>
    /// <param name="dateTime">The constructed <typeparamref name="TSelf"/> represents the same epoch as this <see cref="DateTime"/>.</param>
    public virtual static TSelf FromDateTime(DateTime dateTime) => TSelf.FromJulianDay(JulianDay.FromDateTime(dateTime));
}