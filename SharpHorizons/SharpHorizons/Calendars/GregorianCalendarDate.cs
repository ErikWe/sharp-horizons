namespace SharpHorizons.Calendars;

using SharpMeasures;

using System;
using System.Globalization;

/// <summary>Represents a point in time, expressed according to the Gregorian calendar.</summary>
public record class GregorianCalendarDate : ICalendarDate<GregorianCalendarDate>
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

    /// <summary><inheritdoc cref="GregorianCalendarDate" path="/summary"/></summary>
    /// <param name="year"><inheritdoc cref="Year" path="/summary"/></param>
    /// <param name="month"><inheritdoc cref="Month" path="/summary"/></param>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <param name="hour"><inheritdoc cref="Hour" path="/summary"/></param>
    /// <param name="minute"><inheritdoc cref="Minute" path="/summary"/></param>
    /// <param name="second"><inheritdoc cref="Second" path="/summary"/></param>
    /// <remarks>The constructed <see cref="GregorianCalendarDate"/> is not validated. This can be done post-construction through <see cref="IsValid"/>.</remarks>
    public GregorianCalendarDate(int year, JulianCalendarMonth month, int day, int hour, int minute, double second)
    {
        Year = year;
        Month = month;
        Day = day;

        Hour = hour;
        Minute = minute;
        Second = second;
    }

    /// <summary>Verifies that <see langword="this"/> represents a valid <see cref="GregorianCalendarDate"/>.</summary>
    /// <returns><see langword="true"/> if <see langword="this"/> represents a valid <see cref="GregorianCalendarDate"/>, otherwise <see langword="false"/>.</returns>
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
    public bool IsLeapYear()
    {
        if (Year % 400 is 0)
        {
            return true;
        }

        if (Year % 100 is 0)
        {
            return false;
        }

        return Year % 4 is 0;
    }

    /// <summary>Converts <see langword="this"/> to the equivalent <typeparamref name="TCalendarDate"/>.</summary>
    /// <typeparam name="TCalendarDate"><see langword="this"/> is converted to the equivalent <see cref="ICalendarDate"/> of this type.</typeparam>
    public TCalendarDate ToCalendarDate<TCalendarDate>() where TCalendarDate : ICalendarDate<TCalendarDate> => TCalendarDate.FromJulianDay(ToJulianDay());

    /// <inheritdoc/>
    /// <credit>Astronomical Algorithms, Jean Meeus, chapter 7.</credit>
    public JulianDay ToJulianDay()
    {
        var year = Year;
        var month = (int)Month;

        if (month < 3)
        {
            year -= 1;
            month += 12;
        }

        var a = (int)Math.Floor(year / 100d);
        var b = 2 - a + (int)Math.Floor(a / 4d);

        var julianDay = Math.Floor(365.25 * (year + 4716)) + Math.Floor(30.6001 * (month + 1)) + Day + b - 1524.5;
        var fractionalJulianDay = Hour / 24d + Minute / (24d * 60) + Second / (24d * 60 * 60);

        return new(julianDay + fractionalJulianDay);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public DateTime ToDateTime() => new(Year, (int)Month, Day, Hour, Minute, (int)Second, (int)(Second % 1 * 1000), GregorianCalendar);

    /// <summary>Constructs the <see cref="GregorianCalendarDate"/> equivalent to <paramref name="calendarDate"/>.</summary>
    /// <typeparam name="TCalendarDate">The constructed <see cref="GregorianCalendarDate"/> is equivalent to an <see cref="ICalendarDate"/> of this type.</typeparam>
    /// <param name="calendarDate">The constructed <see cref="GregorianCalendarDate"/> is equivalent to this <typeparamref name="TCalendarDate"/>.</param>
    public static GregorianCalendarDate FromCalendarDate<TCalendarDate>(TCalendarDate calendarDate) where TCalendarDate : ICalendarDate<TCalendarDate> => FromJulianDay(calendarDate.ToJulianDay());

    /// <summary>Constructs the <see cref="GregorianCalendarDate"/> equivalent to <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <see cref="GregorianCalendarDate"/> is equivalent to this <see cref="JulianDay"/>.</param>
    /// <credit>Astronomical Algorithms, Jean Meeus, chapter 7.</credit>
    public static GregorianCalendarDate FromJulianDay(JulianDay julianDay)
    {
        var z = (int)Math.Floor(julianDay.Day + 0.5);
        var f = Modulus(julianDay.Day + 0.5, 1);

        var alpha = (int)Math.Floor((z - 1867216.25) / 36524.25);
        var a = z + 1 + alpha - (int)Math.Floor(alpha / 4d);
        var b = a + 1524;
        var c = (int)Math.Floor((b - 122.1) / 365.25);
        var d = (int)Math.Floor(c * 365.25);
        var e = (int)Math.Floor((b - d) / 30.6001);

        var day = b - d - (int)Math.Floor(30.6001 * e);
        var month = e - (e < 14 ? 1 : 13);
        var year = c - (month > 2 ? 4716 : 4715);

        var hour = (int)(f * 24 + 1d / 60 / 60 / 1000);
        double hourReminder = f - hour * 1d / 24;

        var minute = (int)(hourReminder * 24 * 60 + 1d / 60 / 60 / 1000);
        double minuteReminder = hourReminder - minute * 1d / 24 / 60;

        var second = minuteReminder * 24 * 60 * 60 + 1d / 60 / 1000;

        return new(year, (JulianCalendarMonth)month, day, hour, minute, second);
    }

    /// <summary>Constructs the <see cref="GregorianCalendarDate"/> equivalent to <paramref name="dateTime"/>.</summary>
    /// <param name="dateTime">The constructed <see cref="GregorianCalendarDate"/> is equivalent to this <see cref="DateTime"/>.</param>
    public static GregorianCalendarDate FromDateTime(DateTime dateTime) => new(GregorianCalendar.GetYear(dateTime), (JulianCalendarMonth)(GregorianCalendar.GetMonth(dateTime)), GregorianCalendar.GetDayOfMonth(dateTime), GregorianCalendar.GetHour(dateTime), GregorianCalendar.GetMinute(dateTime), GregorianCalendar.GetSecond(dateTime) + GregorianCalendar.GetMilliseconds(dateTime) / 1000d);

    /// <inheritdoc cref="System.Globalization.GregorianCalendar"/>
    private static GregorianCalendar GregorianCalendar { get; } = new();

    /// <summary>Computes <paramref name="value"/> (mod <paramref name="mod"/>).</summary>
    private static double Modulus(double value, double mod)
    {
        var remainder = value % mod;

        return remainder >= 0 ? remainder : remainder + mod;
    }
}
