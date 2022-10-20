namespace SharpHorizons.Calendars;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents a point in time, expressed as a modified Julian day - the fractional number of days since { 00:00:00, November 17th, 1858 } according to the Gregorian calendar.</summary>
public readonly record struct ModifiedJulianDay : ICalendarDate<ModifiedJulianDay>
{
    /// <summary>The fractional number of days since { 00:00:00, November 17th, 1858 } according to the Gregorian calendar.</summary>
    public double Day { get; }

    /// <summary><inheritdoc cref="JulianDay" path="/summary"/></summary>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    public ModifiedJulianDay(double day)
    {
        Day = day;
    }

    /// <summary>Converts <see langword="this"/> to the equivalent <typeparamref name="TCalendarDate"/>.</summary>
    /// <typeparam name="TCalendarDate"><see langword="this"/> is converted to the equivalent <see cref="ICalendarDate"/> of this type.</typeparam>
    public TCalendarDate ToCalendarDate<TCalendarDate>() where TCalendarDate : ICalendarDate<TCalendarDate> => TCalendarDate.FromJulianDay(ToJulianDay());

    /// <inheritdoc/>
    public JulianDay ToJulianDay() => new(Day + 2400000.5);

    /// <inheritdoc/>
    public DateTime ToDateTime() => JulianCalendarDate.FromJulianDay(ToJulianDay()).ToDateTime();

    /// <summary>Constructs the <see cref="JulianDay"/> equivalent to <paramref name="calendarDate"/>.</summary>
    /// <typeparam name="TCalendarDate">The constructed <see cref="JulianDay"/> is equivalent to an <see cref="ICalendarDate"/> of this type.</typeparam>
    /// <param name="calendarDate">The constructed <see cref="JulianDay"/> is equivalent to this <typeparamref name="TCalendarDate"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public static ModifiedJulianDay FromCalendarDate<TCalendarDate>(TCalendarDate calendarDate) where TCalendarDate : ICalendarDate<TCalendarDate>
    {
        ArgumentNullException.ThrowIfNull(calendarDate);

        return FromJulianDay(calendarDate.ToJulianDay());
    }

    /// <inheritdoc/>
    public static ModifiedJulianDay FromJulianDay(JulianDay julianDay) => new(julianDay.Day - 2400000.5);

    /// <inheritdoc/>
    public static ModifiedJulianDay FromDateTime(DateTime dateTime) => FromJulianDay(JulianDay.FromDateTime(dateTime));

    /// <summary>Computes the time between <see langword="this"/> and <paramref name="final"/>.</summary>
    /// <param name="final">The final point in time.</param>
    public Time Difference(ModifiedJulianDay final) => this - final;

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <see langword="this"/> + <paramref name="difference"/> }.</summary>
    /// <param name="difference">The difference between <see langword="this"/> and the final point in time.</param>
    public ModifiedJulianDay Add(Time difference) => this + difference;

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <see langword="this"/> - <paramref name="difference"/> }.</summary>
    /// <param name="difference">The difference between <see langword="this"/> and the final point in time.</param>
    public ModifiedJulianDay Subtract(Time difference) => this + difference;

    /// <summary>Computes the time between <paramref name="initial"/> and <paramref name="final"/>.</summary>
    /// <param name="initial">The initial point in time.</param>
    /// <param name="final">The final point in time.</param>
    public static Time operator -(ModifiedJulianDay initial, ModifiedJulianDay final) => (initial.Day - final.Day) * Time.OneDay;

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <paramref name="initial"/> + <paramref name="difference"/> }.</summary>
    /// <param name="initial">The initial point in time.</param>
    /// <param name="difference">The difference between the initial and the final point in time.</param>
    public static ModifiedJulianDay operator +(ModifiedJulianDay initial, Time difference) => new(initial.Day + difference.Days);

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <paramref name="initial"/> - <paramref name="difference"/> }..</summary>
    /// <param name="initial">The initial point in time.</param>
    /// <param name="difference">The difference between the initial and the final point in time.</param>
    public static ModifiedJulianDay operator -(ModifiedJulianDay initial, Time difference) => new(initial.Day - difference.Days);
}