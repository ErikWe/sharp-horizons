namespace SharpHorizons.Calendars;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents a point in time, expressed as a Julian day - the fractional number of days since { 12:00:00, January 1st, 4713 BCE } according to the Julian calendar ({ November 24th, 4714 BCE } according to the Gregorian calendar).</summary>
public readonly record struct JulianDay : ICalendarDate<JulianDay>
{
    /// <summary>The fractional number of days since { 12:00:00, January 1st, 4713 BCE } according to the Julian calendar ({ November 24th, 4714 BCE } according to the Gregorian calendar).</summary>
    public double Day { get; }

    /// <summary>Represents the <see cref="JulianDay"/> { <paramref name="day"/> }.</summary>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    public JulianDay(double day)
    {
        Day = day;
    }

    /// <summary>Converts <see langword="this"/> to the equivalent <typeparamref name="TCalendarDate"/>.</summary>
    /// <typeparam name="TCalendarDate"><see langword="this"/> is converted to the equivalent <see cref="ICalendarDate"/> of this type.</typeparam>
    public TCalendarDate ToCalendarDate<TCalendarDate>() where TCalendarDate : ICalendarDate<TCalendarDate> => TCalendarDate.FromJulianDay(this);

    /// <inheritdoc/>
    JulianDay ICalendarDate.ToJulianDay() => this;

    /// <inheritdoc/>
    public DateTime ToDateTime() => JulianCalendarDate.FromJulianDay(this).ToDateTime();

    /// <summary>Constructs the <see cref="JulianDay"/> equivalent to <paramref name="calendarDate"/>.</summary>
    /// <typeparam name="TCalendarDate">The constructed <see cref="JulianDay"/> is equivalent to an <see cref="ICalendarDate"/> of this type.</typeparam>
    /// <param name="calendarDate">The constructed <see cref="JulianDay"/> is equivalent to this <typeparamref name="TCalendarDate"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public static JulianDay FromCalendarDate<TCalendarDate>(TCalendarDate calendarDate) where TCalendarDate : ICalendarDate<TCalendarDate>
    {
        ArgumentNullException.ThrowIfNull(calendarDate);

        return calendarDate.ToJulianDay();
    }

    /// <inheritdoc/>
    static JulianDay ICalendarDate<JulianDay>.FromJulianDay(JulianDay julianDay) => julianDay;

    /// <inheritdoc/>
    public static JulianDay FromDateTime(DateTime dateTime) => JulianCalendarDate.FromDateTime(dateTime).ToJulianDay();

    /// <summary>Computes the time between <see langword="this"/> and <paramref name="final"/>.</summary>
    /// <param name="final">The final point in time.</param>
    public Time Difference(JulianDay final) => this - final;

    /// <summary>Computes the <see cref="JulianDay"/> representing { <see langword="this"/> + <paramref name="difference"/> }.</summary>
    /// <param name="difference">The difference between <see langword="this"/> and the final point in time.</param>
    public JulianDay Add(Time difference) => this + difference;

    /// <summary>Computes the <see cref="JulianDay"/> representing { <see langword="this"/> - <paramref name="difference"/> }.</summary>
    /// <param name="difference">The difference between <see langword="this"/> and the final point in time.</param>
    public JulianDay Subtract(Time difference) => this + difference;

    /// <summary>Computes the time between <paramref name="initial"/> and <paramref name="final"/>.</summary>
    /// <param name="initial">The initial point in time.</param>
    /// <param name="final">The final point in time.</param>
    public static Time operator -(JulianDay initial, JulianDay final) => (initial.Day - final.Day) * Time.OneDay;

    /// <summary>Computes the <see cref="JulianDay"/> representing { <paramref name="initial"/> + <paramref name="difference"/> }.</summary>
    /// <param name="initial">The initial point in time.</param>
    /// <param name="difference">The difference between the initial and the final point in time.</param>
    public static JulianDay operator +(JulianDay initial, Time difference) => new(initial.Day + difference.Days);

    /// <summary>Computes the <see cref="JulianDay"/> representing { <paramref name="initial"/> - <paramref name="difference"/> }..</summary>
    /// <param name="initial">The initial point in time.</param>
    /// <param name="difference">The difference between the initial and the final point in time.</param>
    public static JulianDay operator -(JulianDay initial, Time difference) => new(initial.Day - difference.Days);
}