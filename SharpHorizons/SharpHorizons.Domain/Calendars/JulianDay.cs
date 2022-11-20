namespace SharpHorizons.Calendars;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents an epoch, an instant in time, expressed as a Julian day - the fractional number of days since { 12:00:00, January 1st, 4713 BCE } according to the Julian calendar.</summary>
public sealed record class JulianDay : IEpoch<JulianDay>
{
    /// <summary>The fractional number of days since { 12:00:00, January 1st, 4713 BCE } according to the Julian calendar.</summary>
    public required double Day { get; init; }

    /// <inheritdoc cref="JulianDay"/>
    public JulianDay() { }

    /// <inheritdoc cref="JulianDay"/>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    [SetsRequiredMembers]
    public JulianDay(double day)
    {
        Day = day;
    }

    /// <summary>Converts <see langword="this"/> to the <typeparamref name="TEpoch"/> representing the same epoch.</summary>
    /// <typeparam name="TEpoch"><see langword="this"/> is converted to an <see cref="IEpoch"/> of this type, representing the same epoch.</typeparam>
    public TEpoch ToEpoch<TEpoch>() where TEpoch : IEpoch<TEpoch> => TEpoch.FromJulianDay(this);

    /// <inheritdoc/>
    JulianDay IEpoch.ToJulianDay() => this;

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public DateTime ToDateTime() => JulianCalendarEpoch.FromJulianDay(this).ToDateTime();

    /// <summary>Constructs the <see cref="JulianDay"/> representing the same epoch as <paramref name="epoch"/>.</summary>
    /// <typeparam name="TEpoch">An <see cref="IEpoch"/> of this type is used to construct a <see cref="JulianDay"/> representing the same epoch.</typeparam>
    /// <param name="epoch">The constructed <see cref="JulianDay"/> represents the same epoch as this <typeparamref name="TEpoch"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public static JulianDay FromEpoch<TEpoch>(TEpoch epoch) where TEpoch : IEpoch<TEpoch>
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return epoch.ToJulianDay();
    }

    /// <inheritdoc/>
    static JulianDay IEpoch<JulianDay>.FromJulianDay(JulianDay julianDay) => julianDay;

    /// <inheritdoc/>
    public static JulianDay FromDateTime(DateTime dateTime) => JulianCalendarEpoch.FromDateTime(dateTime).ToJulianDay();

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }.</summary>
    /// <param name="initial">The initial epoch.</param>
    public Time Difference(JulianDay initial) => this - initial;

    /// <summary>Computes the <see cref="JulianDay"/> representing { <see langword="this"/> + <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> and the resulting epoch.</param>
    public JulianDay Add(Time difference) => this + difference;

    /// <summary>Computes the <see cref="JulianDay"/> representing { <see langword="this"/> - <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between the <see langword="this"/> and the resulting epoch.</param>
    public JulianDay Subtract(Time difference) => this + difference;

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/>.</summary>
    /// <param name="initial">The initial epoch.</param>
    /// <param name="final">The final epoch.</param>
    public static Time operator -(JulianDay final, JulianDay initial) => (initial.Day - final.Day) * Time.OneDay;

    /// <summary>Computes the <see cref="JulianDay"/> representing { <paramref name="initial"/> + <paramref name="difference"/> }.</summary>
    /// <param name="initial">The initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between <paramref name="initial"/> and <paramref name="difference"/>.</param>
    public static JulianDay operator +(JulianDay initial, Time difference) => new(initial.Day + difference.Days);

    /// <summary>Computes the <see cref="JulianDay"/> representing { <paramref name="initial"/> - <paramref name="difference"/> }.</summary>
    /// <param name="initial">The initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between <paramref name="initial"/> and the resulting epoch.</param>
    public static JulianDay operator -(JulianDay initial, Time difference) => new(initial.Day - difference.Days);
}