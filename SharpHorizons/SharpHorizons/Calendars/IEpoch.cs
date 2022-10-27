namespace SharpHorizons.Calendars;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents an epoch, an instant in time, expressed in some calendar.</summary>
public interface IEpoch
{
    /// <summary>Converts <see langword="this"/> to the equivalent <typeparamref name="TEpoch"/>.</summary>
    /// <typeparam name="TEpoch"><see langword="this"/> is converted to the equivalent <see cref="IEpoch"/> of this type.</typeparam>
    public abstract TEpoch ToEpoch<TEpoch>() where TEpoch : IEpoch<TEpoch>;

    /// <summary>Converts <see langword="this"/> to the equivalent <see cref="JulianDay"/>.</summary>
    public abstract JulianDay ToJulianDay();

    /// <summary>Converts <see langword="this"/> to the equivalent <see cref="DateTime"/>.</summary>
    public abstract DateTime ToDateTime();
}

/// <inheritdoc/>
public interface IEpoch<TSelf> : IEpoch where TSelf : IEpoch<TSelf>
{
    /// <summary>Constructs the <typeparamref name="TSelf"/> equivalent to <paramref name="calendarDate"/>.</summary>
    /// <typeparam name="TEpoch">The constructed <typeparamref name="TSelf"/> is equivalent to an <see cref="IEpoch"/> of this type.</typeparam>
    /// <param name="calendarDate">The constructed <typeparamref name="TSelf"/> is equivalent to this <typeparamref name="TEpoch"/>.</param>
    [SuppressMessage("Design", "CA1000", Justification = "Implementing type is not necessarily generic.")]
    public abstract static TSelf FromEpoch<TEpoch>(TEpoch calendarDate) where TEpoch : IEpoch<TEpoch>;

    /// <summary>Constructs the <typeparamref name="TSelf"/> equivalent to <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <typeparamref name="TSelf"/> is equivalent to this <see cref="JulianDay"/>.</param>
    [SuppressMessage("Design", "CA1000", Justification = "Implementing type is not necessarily generic.")]
    public abstract static TSelf FromJulianDay(JulianDay julianDay);

    /// <summary>Constructs the <typeparamref name="TSelf"/> equivalent to <paramref name="dateTime"/>.</summary>
    /// <param name="dateTime">The constructed <typeparamref name="TSelf"/> is equivalent to this <see cref="DateTime"/>.</param>
    [SuppressMessage("Design", "CA1000", Justification = "Implementing type is not necessarily generic.")]
    public abstract static TSelf FromDateTime(DateTime dateTime);
}