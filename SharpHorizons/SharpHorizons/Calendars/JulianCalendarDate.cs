namespace SharpHorizons.Calendars;

using SharpMeasures;

using System;
using System.Globalization;

/// <summary>Represents an epoch, an instant in time, expressed according to the Julian calendar.</summary>
public record class JulianCalendarDate : IEpoch<JulianCalendarDate>
{
    /// <summary>The year.</summary>
    public int Year { get; }
    /// <summary>The month.</summary>
    public JulianCalendarMonth Month { get; }
    /// <summary>The one-indexed day-of-the-month.</summary>
    public int Day { get; }

    /// <summary>The hour.</summary>
    public int Hour { get; }
    /// <summary>The minute.</summary>
    public int Minute { get; }
    /// <summary>The fractional second.</summary>
    public double Second { get; }

    /// <summary>Represents the date { <paramref name="year"/>, <paramref name="month"/>, <paramref name="day"/> } and time { <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/> } in the Julian calendar.</summary>
    /// <param name="year"><inheritdoc cref="Year" path="/summary"/></param>
    /// <param name="month"><inheritdoc cref="Month" path="/summary"/></param>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <param name="hour"><inheritdoc cref="Hour" path="/summary"/></param>
    /// <param name="minute"><inheritdoc cref="Minute" path="/summary"/></param>
    /// <param name="second"><inheritdoc cref="Second" path="/summary"/></param>
    /// <remarks>The constructed <see cref="JulianCalendarDate"/> is not validated. This can be done post-construction through <see cref="IsValid"/>.</remarks>
    public JulianCalendarDate(int year, JulianCalendarMonth month, int day, int hour, int minute, double second)
    {
        Year = year;
        Month = month;
        Day = day;

        Hour = hour;
        Minute = minute;
        Second = second;
    }
    /// <summary>Represents the date { <paramref name="year"/>, <paramref name="month"/>, <paramref name="day"/> } and time { 0:00:00 } (first second of the day) in the Julian calendar.</summary>
    /// <param name="year"><inheritdoc cref="Year" path="/summary"/></param>
    /// <param name="month"><inheritdoc cref="Month" path="/summary"/></param>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <remarks>The constructed <see cref="JulianCalendarDate"/> is not validated. This can be done post-construction through <see cref="IsValid"/>.</remarks>
    public JulianCalendarDate(int year, JulianCalendarMonth month, int day) : this(year, month, day, 0, 0, 0) { }

    /// <summary>Verifies that <see langword="this"/> represents a valid <see cref="JulianCalendarDate"/>.</summary>
    /// <returns><see langword="true"/> if <see langword="this"/> represents a valid <see cref="JulianCalendarDate"/>, otherwise <see langword="false"/>.</returns>
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

    /// <summary>Checks whether the represented point in time belongs to a leap year.</summary>
    public bool IsLeapYear() => (Year + (Year < 0 ? 1 : 0)) % 4 is 0;

    /// <summary>Converts <see langword="this"/> to the equivalent <typeparamref name="TCalendarDate"/>.</summary>
    /// <typeparam name="TCalendarDate"><see langword="this"/> is converted to the equivalent <see cref="IEpoch"/> of this type.</typeparam>
    public TCalendarDate ToEpoch<TCalendarDate>() where TCalendarDate : IEpoch<TCalendarDate> => TCalendarDate.FromJulianDay(ToJulianDay());

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
        var fractionalJulianDay = Hour / 24d + Minute / (24d * 60) + Second / (24d * 60 * 60);

        return new(julianDay + fractionalJulianDay);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public DateTime ToDateTime() => new(Year, (int)Month, Day, Hour, Minute, (int)Second, (int)(Second % 1 * 1000), JulianCalendar);

    /// <summary>Constructs the <see cref="JulianCalendarDate"/> equivalent to <paramref name="calendarDate"/>.</summary>
    /// <typeparam name="TCalendarDate">The constructed <see cref="JulianCalendarDate"/> is equivalent to an <see cref="IEpoch"/> of this type.</typeparam>
    /// <param name="calendarDate">The constructed <see cref="JulianCalendarDate"/> is equivalent to this <typeparamref name="TCalendarDate"/>.</param>
    public static JulianCalendarDate FromEpoch<TCalendarDate>(TCalendarDate calendarDate) where TCalendarDate : IEpoch<TCalendarDate> => FromJulianDay(calendarDate.ToJulianDay());

    /// <summary>Constructs the <see cref="JulianCalendarDate"/> equivalent to <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <see cref="JulianCalendarDate"/> is equivalent to this <see cref="JulianDay"/>.</param>
    /// <credit>Astronomical Algorithms, Jean Meeus, chapter 7.</credit>
    public static JulianCalendarDate FromJulianDay(JulianDay julianDay)
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

    /// <summary>Constructs the <see cref="JulianCalendarDate"/> equivalent to <paramref name="dateTime"/>.</summary>
    /// <param name="dateTime">The constructed <see cref="JulianCalendarDate"/> is equivalent to this <see cref="DateTime"/>.</param>
    public static JulianCalendarDate FromDateTime(DateTime dateTime) => new(JulianCalendar.GetYear(dateTime), (JulianCalendarMonth)(JulianCalendar.GetMonth(dateTime)), JulianCalendar.GetDayOfMonth(dateTime), JulianCalendar.GetHour(dateTime), JulianCalendar.GetMinute(dateTime), JulianCalendar.GetSecond(dateTime) + JulianCalendar.GetMilliseconds(dateTime) / 1000d);

    /// <inheritdoc cref="System.Globalization.JulianCalendar"/>
    private static JulianCalendar JulianCalendar { get; } = new();

    /// <summary>Computes <paramref name="value"/> (mod <paramref name="mod"/>).</summary>
    private static double Modulus(double value, double mod)
    {
        var remainder = value % mod;

        return remainder >= 0 ? remainder : remainder + mod;
    }
}
