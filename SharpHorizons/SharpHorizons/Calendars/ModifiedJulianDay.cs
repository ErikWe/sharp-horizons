namespace SharpHorizons.Calendars;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents an epoch, an instant in time, expressed as a modified Julian day - the fractional number of days since { 00:00:00, November 17th, 1858 CE } according to the Gregorian calendar.</summary>
public readonly record struct ModifiedJulianDay : IEpoch<ModifiedJulianDay>
{
    /// <summary>The fractional number of days since { 00:00:00, November 17th, 1858 CE } according to the Gregorian calendar.</summary>
    public double Day { get; }

    /// <summary><inheritdoc cref="ModifiedJulianDay" path="/summary"/></summary>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    public ModifiedJulianDay(double day)
    {
        Day = day;
    }

    /// <summary>Converts <see langword="this"/> to the <typeparamref name="TEpoch"/> representing the same epoch.</summary>
    /// <typeparam name="TEpoch"><see langword="this"/> is converted to an <see cref="IEpoch"/> of this type, representing the same epoch.</typeparam>
    public TEpoch ToEpoch<TEpoch>() where TEpoch : IEpoch<TEpoch> => TEpoch.FromJulianDay(ToJulianDay());

    /// <inheritdoc/>
    public JulianDay ToJulianDay() => new(Day + 2400000.5);

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public DateTime ToDateTime() => ToJulianDay().ToDateTime();

    /// <summary>Constructs the <see cref="ModifiedJulianDay"/> representing the same epoch as <paramref name="epoch"/>.</summary>
    /// <typeparam name="TEpoch">An <see cref="IEpoch"/> of this type is used to construct a <see cref="ModifiedJulianDay"/> representing the same epoch.</typeparam>
    /// <param name="epoch">The constructed <see cref="ModifiedJulianDay"/> represents the same epoch as this <typeparamref name="TEpoch"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public static ModifiedJulianDay FromEpoch<TEpoch>(TEpoch epoch) where TEpoch : IEpoch<TEpoch>
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return FromJulianDay(epoch.ToJulianDay());
    }

    /// <inheritdoc/>
    public static ModifiedJulianDay FromJulianDay(JulianDay julianDay) => new(julianDay.Day - 2400000.5);

    /// <inheritdoc/>
    public static ModifiedJulianDay FromDateTime(DateTime dateTime) => FromJulianDay(JulianDay.FromDateTime(dateTime));

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }.</summary>
    /// <param name="initial">The initial epoch.</param>
    public Time Difference(ModifiedJulianDay initial) => this - initial;

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <see langword="this"/> + <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> and the resulting epoch.</param>
    public ModifiedJulianDay Add(Time difference) => this + difference;

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <see langword="this"/> - <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between the <see langword="this"/> and the resulting epoch.</param>
    public ModifiedJulianDay Subtract(Time difference) => this + difference;

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/>.</summary>
    /// <param name="initial">The initial epoch.</param>
    /// <param name="final">The final epoch.</param>
    public static Time operator -(ModifiedJulianDay final, ModifiedJulianDay initial) => (final.Day - initial.Day) * Time.OneDay;

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <paramref name="initial"/> + <paramref name="difference"/> }.</summary>
    /// <param name="initial">The initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between <paramref name="initial"/> and <paramref name="difference"/>.</param>
    public static ModifiedJulianDay operator +(ModifiedJulianDay initial, Time difference) => new(initial.Day + difference.Days);

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <paramref name="initial"/> - <paramref name="difference"/> }..</summary>
    /// <param name="initial">The initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between <paramref name="initial"/> and the resulting epoch.</param>
    public static ModifiedJulianDay operator -(ModifiedJulianDay initial, Time difference) => new(initial.Day - difference.Days);
}