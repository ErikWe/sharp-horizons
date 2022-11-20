namespace SharpHorizons.Calendars;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents an epoch, an instant in time, expressed according to the Julian calendar.</summary>
public sealed record class JulianCalendarEpoch : IEpoch<JulianCalendarEpoch>
{
    /// <summary>The year of the <see cref="JulianCalendarEpoch"/>.</summary>
    public required int Year { get; init; }
    /// <summary>The month of the <see cref="JulianCalendarEpoch"/>.</summary>
    public required JulianCalendarMonth Month { get; init; }
    /// <summary>The one-indexed day-of-the-month of the <see cref="JulianCalendarEpoch"/>.</summary>
    public required int Day { get; init; }

    /// <summary>The hour of the <see cref="JulianCalendarEpoch"/>.</summary>
    public int Hour { get; init; }
    /// <summary>The minute of the <see cref="JulianCalendarEpoch"/>.</summary>
    public int Minute { get; init; }
    /// <summary>The fractional second of the <see cref="JulianCalendarEpoch"/>.</summary>
    public double Second { get; init; }

    /// <inheritdoc cref="JulianCalendarEpoch"/>
    /// <remarks>The constructed <see cref="JulianCalendarEpoch"/> is not validated. This can be done post-construction through <see cref="IsValid"/>.</remarks>
    public JulianCalendarEpoch() { }

    /// <inheritdoc cref="JulianCalendarEpoch"/>
    /// <param name="year"><inheritdoc cref="Year" path="/summary"/></param>
    /// <param name="month"><inheritdoc cref="Month" path="/summary"/></param>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <remarks>The constructed <see cref="JulianCalendarEpoch"/> is not validated. This can be done post-construction through <see cref="IsValid"/>.</remarks>
    [SetsRequiredMembers]
    public JulianCalendarEpoch(int year, JulianCalendarMonth month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
    }

    /// <inheritdoc cref="JulianCalendarEpoch"/>
    /// <param name="year"><inheritdoc cref="Year" path="/summary"/></param>
    /// <param name="month"><inheritdoc cref="Month" path="/summary"/></param>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <param name="hour"><inheritdoc cref="Hour" path="/summary"/></param>
    /// <remarks>The constructed <see cref="JulianCalendarEpoch"/> is not validated. This can be done post-construction through <see cref="IsValid"/>.</remarks>
    [SetsRequiredMembers]
    public JulianCalendarEpoch(int year, JulianCalendarMonth month, int day, int hour)
    {
        Year = year;
        Month = month;
        Day = day;

        Hour = hour;
    }

    /// <inheritdoc cref="JulianCalendarEpoch"/>
    /// <param name="year"><inheritdoc cref="Year" path="/summary"/></param>
    /// <param name="month"><inheritdoc cref="Month" path="/summary"/></param>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <param name="hour"><inheritdoc cref="Hour" path="/summary"/></param>
    /// <param name="minute"><inheritdoc cref="Minute" path="/summary"/></param>
    /// <remarks>The constructed <see cref="JulianCalendarEpoch"/> is not validated. This can be done post-construction through <see cref="IsValid"/>.</remarks>
    [SetsRequiredMembers]
    public JulianCalendarEpoch(int year, JulianCalendarMonth month, int day, int hour, int minute)
    {
        Year = year;
        Month = month;
        Day = day;

        Hour = hour;
        Minute = minute;
    }

    /// <inheritdoc cref="JulianCalendarEpoch"/>
    /// <param name="year"><inheritdoc cref="Year" path="/summary"/></param>
    /// <param name="month"><inheritdoc cref="Month" path="/summary"/></param>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <param name="hour"><inheritdoc cref="Hour" path="/summary"/></param>
    /// <param name="minute"><inheritdoc cref="Minute" path="/summary"/></param>
    /// <param name="second"><inheritdoc cref="Second" path="/summary"/></param>
    /// <remarks>The constructed <see cref="JulianCalendarEpoch"/> is not validated. This can be done post-construction through <see cref="IsValid"/>.</remarks>
    [SetsRequiredMembers]
    public JulianCalendarEpoch(int year, JulianCalendarMonth month, int day, int hour, int minute, double second)
    {
        Year = year;
        Month = month;
        Day = day;

        Hour = hour;
        Minute = minute;
        Second = second;
    }

    /// <summary>Determines whether <see langword="this"/> represents a valid <see cref="JulianCalendarEpoch"/>.</summary>
    /// <remarks>For example, a date { February 29th, 2021 CE } or a time { 11:30:72 } would cause the corresponding <see cref="JulianCalendarEpoch"/> to be considered invalid.</remarks>
    public bool IsValid()
    {
        if (Year is 0 || Enum.IsDefined(Month) is false || Day is < 1 or > 31 || Hour is < 0 or > 23 || Minute is < 0 or > 59 || Second is < 0 or > 59)
        {
            return false;
        }

        if (Month is JulianCalendarMonth.February)
        {
            return Day is < 29 || Day is 29 && IsLeapYear();
        }

        if (Day < 31)
        {
            return true;
        }

        return Month is JulianCalendarMonth.January or JulianCalendarMonth.March or JulianCalendarMonth.May or JulianCalendarMonth.July or JulianCalendarMonth.August or JulianCalendarMonth.October or JulianCalendarMonth.December;
    }

    /// <summary>Determines whether <see langword="this"/> represents an <see cref="IEpoch"/> that belongs to a leap year, according to the Julian calendar.</summary>
    public bool IsLeapYear() => (Year + (Year < 0 ? 1 : 0)) % 4 is 0;

    /// <summary>Converts <see langword="this"/> to the <typeparamref name="TEpoch"/> representing the same epoch.</summary>
    /// <typeparam name="TEpoch"><see langword="this"/> is converted to an <see cref="IEpoch"/> of this type, representing the same epoch.</typeparam>
    public TEpoch ToEpoch<TEpoch>() where TEpoch : IEpoch<TEpoch> => TEpoch.FromJulianDay(ToJulianDay());

    /// <inheritdoc/>
    /// <credit>Astronomical Algorithms, Jean Meeus, chapter 7.</credit>
    public JulianDay ToJulianDay()
    {
        var year = Year;
        var month = (int)Month;

        if (year < 0)
        {
            year += 1;
        }

        if (month < 3)
        {
            year -= 1;
            month += 12;
        }

        var julianDay = Math.Floor(365.25 * (year + 4716)) + Math.Floor(30.6001 * (month + 1)) + Day - 1524.5;
        var fractionalDay = Hour / 24d + Minute / (24d * 60) + Second / (24d * 60 * 60);

        return new(julianDay + fractionalDay);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public DateTime ToDateTime() => new(Year, (int)Month, Day, Hour, Minute, (int)Second, (int)(Second % 1 * 1000), JulianCalendar);

    /// <summary>Constructs the <see cref="JulianCalendarEpoch"/> representing the same epoch as <paramref name="epoch"/>.</summary>
    /// <typeparam name="TEpoch">An <see cref="IEpoch"/> of this type is used to construct a <see cref="JulianCalendarEpoch"/> representing the same epoch.</typeparam>
    /// <param name="epoch">The constructed <see cref="JulianCalendarEpoch"/> represents the same epoch as this <typeparamref name="TEpoch"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public static JulianCalendarEpoch FromEpoch<TEpoch>(TEpoch epoch) where TEpoch : IEpoch<TEpoch>
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return FromJulianDay(epoch.ToJulianDay());
    }

    /// <summary>Constructs the <see cref="JulianCalendarEpoch"/> representing the same epoch as <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <see cref="JulianCalendarEpoch"/> represents the same epoch as this <see cref="JulianDay"/>.</param>
    /// <credit>Astronomical Algorithms, Jean Meeus, chapter 7.</credit>
    public static JulianCalendarEpoch FromJulianDay(JulianDay julianDay)
    {
        var z = (int)Math.Floor(julianDay.Day + 0.5);
        var f = Modulus(julianDay.Day + 0.5, 1);

        var a = z;
        var b = a + 1524;
        var c = (int)Math.Floor((b - 122.1) / 365.25);
        var d = (int)Math.Floor(c * 365.25);
        var e = (int)Math.Floor((b - d) / 30.6001);

        var day = b - d - (int)Math.Floor(30.6001 * e);
        var month = e - (e < 14 ? 1 : 13);
        var year = c - (month > 2 ? 4716 : 4715);

        if (year <= 0)
        {
            year -= 1;
        }

        var hour = (int)(f * 24 + 1d / 60 / 60 / 1000);
        double hourReminder = f - hour * 1d / 24;

        var minute = (int)(hourReminder * 24 * 60 + 1d / 60 / 60 / 1000);
        double minuteReminder = hourReminder - minute * 1d / 24 / 60;

        var second = minuteReminder * 24 * 60 * 60 + 1d / 60 / 1000;

        return new(year, (JulianCalendarMonth)month, day, hour, minute, second);
    }

    /// <summary>Constructs the <see cref="JulianCalendarEpoch"/> representing the same epoch as <paramref name="dateTime"/>.</summary>
    /// <param name="dateTime">The constructed <see cref="JulianCalendarEpoch"/> represents the same epoch as this <see cref="DateTime"/>.</param>
    public static JulianCalendarEpoch FromDateTime(DateTime dateTime) => new()
    {
        Year = JulianCalendar.GetYear(dateTime),
        Month = (JulianCalendarMonth)(JulianCalendar.GetMonth(dateTime)),
        Day = JulianCalendar.GetDayOfMonth(dateTime),
        Hour = JulianCalendar.GetHour(dateTime),
        Minute = JulianCalendar.GetMinute(dateTime),
        Second = JulianCalendar.GetSecond(dateTime) + JulianCalendar.GetMilliseconds(dateTime) / 1000d
    };

    /// <inheritdoc cref="System.Globalization.JulianCalendar"/>
    private static JulianCalendar JulianCalendar { get; } = new();

    /// <summary>Computes <paramref name="value"/> (mod <paramref name="mod"/>).</summary>
    private static double Modulus(double value, double mod)
    {
        var remainder = value % mod;

        return remainder >= 0 ? remainder : remainder + mod;
    }
}
