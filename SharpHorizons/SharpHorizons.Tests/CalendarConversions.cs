namespace SharpHorizons.Test;

using SharpHorizons.Calendars;

using System.Collections.Generic;

using Xunit;

/// <credit>Online converter: https://www.fourmilab.ch/documents/calendar/</credit>
public class CalendarConversions
{
    [Theory]
    [MemberData(nameof(JulianDaysAndModifiedJulianDays))]
    public void JulianDayToModifiedJulianDay(double julianDay, double modifiedJulianDay)
    {
        ModifiedJulianDay expected = new(modifiedJulianDay);

        ModifiedJulianDay x = ModifiedJulianDay.FromJulianDay(new JulianDay(julianDay));
        ModifiedJulianDay y = ModifiedJulianDay.FromEpoch(new JulianDay(julianDay));
        ModifiedJulianDay z = new JulianDay(julianDay).ToEpoch<ModifiedJulianDay>();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
        AssertApproximatelyEqual(expected, z);
    }

    [Theory]
    [MemberData(nameof(JulianDaysAndJulianDates))]
    public void JulianDayToJulianDate(double julianDay, int year, JulianCalendarMonth month, int day, int hour, int minute, double second)
    {
        JulianCalendarDate expected = new(year, month, day, hour, minute, second);

        JulianCalendarDate x = JulianCalendarDate.FromJulianDay(new JulianDay(julianDay));
        JulianCalendarDate y = JulianCalendarDate.FromEpoch(new JulianDay(julianDay));
        JulianCalendarDate z = new JulianDay(julianDay).ToEpoch<JulianCalendarDate>();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
        AssertApproximatelyEqual(expected, z);
    }

    [Theory]
    [MemberData(nameof(JulianDaysAndGregorianDates))]
    public void JulianDayToGregorianDate(double julianDay, int year, JulianCalendarMonth month, int day, int hour, int minute, double second)
    {
        GregorianCalendarDate expected = new(year, month, day, hour, minute, second);

        GregorianCalendarDate x = GregorianCalendarDate.FromJulianDay(new JulianDay(julianDay));
        GregorianCalendarDate y = GregorianCalendarDate.FromEpoch(new JulianDay(julianDay));
        GregorianCalendarDate z = new JulianDay(julianDay).ToEpoch<GregorianCalendarDate>();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
        AssertApproximatelyEqual(expected, z);
    }

    [Theory]
    [MemberData(nameof(JulianDaysAndModifiedJulianDays))]
    public void ModifiedJulianDayToJulianDay(double julianDay, double modifiedJulianDay)
    {
        JulianDay expected = new(julianDay);

        JulianDay x = JulianDay.FromEpoch(new ModifiedJulianDay(modifiedJulianDay));
        JulianDay y = new ModifiedJulianDay(modifiedJulianDay).ToEpoch<JulianDay>();
        JulianDay z = new ModifiedJulianDay(modifiedJulianDay).ToJulianDay();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
        AssertApproximatelyEqual(expected, z);
    }

    [Theory]
    [MemberData(nameof(ModifiedJulianDaysAndJulianDates))]
    public void ModifiedJulianDayToJulianDate(double modifiedJulianDay, int year, JulianCalendarMonth month, int day, int hour, int minute, double second)
    {
        JulianCalendarDate expected = new(year, month, day, hour, minute, second);

        JulianCalendarDate x = JulianCalendarDate.FromEpoch(new ModifiedJulianDay(modifiedJulianDay));
        JulianCalendarDate y = new ModifiedJulianDay(modifiedJulianDay).ToEpoch<JulianCalendarDate>();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
    }

    [Theory]
    [MemberData(nameof(ModifiedJulianDaysAndGregorianDates))]
    public void ModifiedJulianDayToGregorianDate(double modifiedJulianDay, int year, JulianCalendarMonth month, int day, int hour, int minute, double second)
    {
        GregorianCalendarDate expected = new(year, month, day, hour, minute, second);

        GregorianCalendarDate x = GregorianCalendarDate.FromEpoch(new ModifiedJulianDay(modifiedJulianDay));
        GregorianCalendarDate y = new ModifiedJulianDay(modifiedJulianDay).ToEpoch<GregorianCalendarDate>();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
    }

    [Theory]
    [MemberData(nameof(JulianDaysAndJulianDates))]
    public void JulianDateToJulianDay(double julianDay, int year, JulianCalendarMonth month, int day, int hour, int minute, double second)
    {
        JulianDay expected = new(julianDay);
        JulianCalendarDate julianDate = new(year, month, day, hour, minute, second);

        JulianDay x = JulianDay.FromEpoch(julianDate);
        JulianDay y = julianDate.ToJulianDay();
        JulianDay z = julianDate.ToEpoch<JulianDay>();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
        AssertApproximatelyEqual(expected, z);
    }

    [Theory]
    [MemberData(nameof(ModifiedJulianDaysAndJulianDates))]
    public void JulianDateToModifiedJulianDay(double modifiedJulianDay, int year, JulianCalendarMonth month, int day, int hour, int minute, double second)
    {
        ModifiedJulianDay expected = new(modifiedJulianDay);
        JulianCalendarDate julianDate = new(year, month, day, hour, minute, second);

        ModifiedJulianDay x = ModifiedJulianDay.FromEpoch(julianDate);
        ModifiedJulianDay y = julianDate.ToEpoch<ModifiedJulianDay>();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
    }

    [Theory]
    [MemberData(nameof(JulianDatesAndGregorianDates))]
    public void JulianDateToGregorianDate(int julianYear, JulianCalendarMonth julianMonth, int julianDay, int gregorianYear, JulianCalendarMonth gregorianMonth, int gregorianDay, int hour, int minute, double second)
    {
        GregorianCalendarDate expected = new(gregorianYear, gregorianMonth, gregorianDay, hour, minute, second);
        JulianCalendarDate julianDate = new(julianYear, julianMonth, julianDay, hour, minute, second);

        GregorianCalendarDate x = GregorianCalendarDate.FromEpoch(julianDate);
        GregorianCalendarDate y = julianDate.ToEpoch<GregorianCalendarDate>();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
    }

    [Theory]
    [MemberData(nameof(JulianDaysAndGregorianDates))]
    public void GregorianDateToJulianDay(double julianDay, int year, JulianCalendarMonth month, int day, int hour, int minute, double second)
    {
        JulianDay expected = new(julianDay);
        GregorianCalendarDate julianDate = new(year, month, day, hour, minute, second);

        JulianDay x = JulianDay.FromEpoch(julianDate);
        JulianDay y = julianDate.ToJulianDay();
        JulianDay z = julianDate.ToEpoch<JulianDay>();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
        AssertApproximatelyEqual(expected, z);
    }

    [Theory]
    [MemberData(nameof(ModifiedJulianDaysAndGregorianDates))]
    public void GregorianDateToModifiedJulianDay(double modifiedJulianDay, int year, JulianCalendarMonth month, int day, int hour, int minute, double second)
    {
        ModifiedJulianDay expected = new(modifiedJulianDay);
        GregorianCalendarDate julianDate = new(year, month, day, hour, minute, second);

        ModifiedJulianDay x = ModifiedJulianDay.FromEpoch(julianDate);
        ModifiedJulianDay y = julianDate.ToEpoch<ModifiedJulianDay>();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
    }

    [Theory]
    [MemberData(nameof(JulianDatesAndGregorianDates))]
    public void GregorianDateToJulianDate(int julianYear, JulianCalendarMonth julianMonth, int julianDay, int gregorianYear, JulianCalendarMonth gregorianMonth, int gregorianDay, int hour, int minute, double second)
    {
        JulianCalendarDate expected = new(julianYear, julianMonth, julianDay, hour, minute, second);
        GregorianCalendarDate gregorianDate = new(gregorianYear, gregorianMonth, gregorianDay, hour, minute, second);

        JulianCalendarDate x = JulianCalendarDate.FromEpoch(gregorianDate);
        JulianCalendarDate y = gregorianDate.ToEpoch<JulianCalendarDate>();

        AssertApproximatelyEqual(expected, x);
        AssertApproximatelyEqual(expected, y);
    }

    private static void AssertApproximatelyEqual(JulianDay expected, JulianDay actual)
    {
        Assert.Equal(expected.Day, actual.Day, 3);
    }

    private static void AssertApproximatelyEqual(ModifiedJulianDay expected, ModifiedJulianDay actual)
    {
        Assert.Equal(expected.Day, actual.Day, 3);
    }

    private static void AssertApproximatelyEqual(JulianCalendarDate expected, JulianCalendarDate actual)
    {
        Assert.Equal(expected.Year, actual.Year);
        Assert.Equal(expected.Month, actual.Month);
        Assert.Equal(expected.Day, actual.Day);
        Assert.Equal(expected.Hour, actual.Hour);
        Assert.Equal(expected.Minute, actual.Minute);
        Assert.Equal(expected.Second, actual.Second, 3);
    }

    private static void AssertApproximatelyEqual(GregorianCalendarDate expected, GregorianCalendarDate actual)
    {
        Assert.Equal(expected.Year, actual.Year);
        Assert.Equal(expected.Month, actual.Month);
        Assert.Equal(expected.Day, actual.Day);
        Assert.Equal(expected.Hour, actual.Hour);
        Assert.Equal(expected.Minute, actual.Minute);
        Assert.Equal(expected.Second, actual.Second, 3);
    }

    public static IEnumerable<object[]> JulianDays() => new object[][]
    {
        new object[] { 0 },
        new object[] { 1 },
        new object[] { 1.25 },
        new object[] { 1.75 },
        new object[] { -2 },
        new object[] { -2.25 },
        new object[] { 3919.75 },
        new object[] { 2459872.499988426 },
        new object[] { 2459872.5 },
        new object[] { 2459873.2196180555 },
        new object[] { 9107650.499988426 },
        new object[] { -5664946.5000115745 },
        new object[] { 1721351.45 },
        new object[] { 1721442.89 }
    };

    public static IEnumerable<object[]> ModifiedJulianDays() => new object[][]
    {
        new object[] { -2400000.5 },
        new object[] { -2399999.5 },
        new object[] { -2399999.25 },
        new object[] { -2399998.75 },
        new object[] { -2400002.5 },
        new object[] { -2400002.75 },
        new object[] { -2396080.75 },
        new object[] { 59871.999988426 },
        new object[] { 59872 },
        new object[] { 59872.7196180555 },
        new object[] { 6707649.999988426 },
        new object[] { -8064947.0000115745 },
        new object[] { -678649.05 },
        new object[] { -678557.6100000001 }
    };

    public static IEnumerable<object[]> JulianDates() => new object[][]
    {
        new object[] { -4713, JulianCalendarMonth.January, 1, 12, 0, 0 },
        new object[] { -4713, JulianCalendarMonth.January, 2, 12, 0, 0 },
        new object[] { -4713, JulianCalendarMonth.January, 2, 18, 0, 0 },
        new object[] { -4713, JulianCalendarMonth.January, 3, 6, 0, 0 },
        new object[] { -4714, JulianCalendarMonth.December, 30, 12, 0, 0 },
        new object[] { -4714, JulianCalendarMonth.December, 30, 6, 0, 0 },
        new object[] { -4703, JulianCalendarMonth.September, 25, 6, 0, 0 },
        new object[] { 2022, JulianCalendarMonth.October, 6, 23, 59, 59 },
        new object[] { 2022, JulianCalendarMonth.October, 7, 0, 0, 0 },
        new object[] { 2022, JulianCalendarMonth.October, 7, 17, 16, 15 },
        new object[] { 20223, JulianCalendarMonth.May, 22, 23, 59, 59 },
        new object[] { -20223, JulianCalendarMonth.March, 22, 23, 59, 59 },
        new object[] { -1, JulianCalendarMonth.October, 20, 22, 48, 0 },
        new object[] { 1, JulianCalendarMonth.January, 20, 9, 21, 36 }
    };

    public static IEnumerable<object[]> GregorianDates() => new object[][]
    {
        new object[] { -4713, JulianCalendarMonth.November, 24, 12, 0, 0 },
        new object[] { -4713, JulianCalendarMonth.November, 25, 12, 0, 0 },
        new object[] { -4713, JulianCalendarMonth.November, 25, 18, 0, 0 },
        new object[] { -4713, JulianCalendarMonth.November, 26, 6, 0, 0 },
        new object[] { -4713, JulianCalendarMonth.November, 22, 12, 0, 0 },
        new object[] { -4713, JulianCalendarMonth.November, 22, 6, 0, 0 },
        new object[] { -4702, JulianCalendarMonth.August, 18, 6, 0, 0 },
        new object[] { 2022, JulianCalendarMonth.October, 19, 23, 59, 59 },
        new object[] { 2022, JulianCalendarMonth.October, 20, 0, 0, 0 },
        new object[] { 2022, JulianCalendarMonth.October, 20, 17, 16, 15 },
        new object[] { 20223, JulianCalendarMonth.October, 19, 23, 59, 59 },
        new object[] { -20223, JulianCalendarMonth.October, 19, 23, 59, 59 },
        new object[] { 0, JulianCalendarMonth.October, 18, 22, 48, 0 },
        new object[] { 1, JulianCalendarMonth.January, 18, 9, 21, 36 }
    };

    public static IEnumerable<object[]> JulianDaysAndModifiedJulianDays()
    {
        var julianDayEnumerator = JulianDays().GetEnumerator();
        var modifiedJulianDayEnumerator = ModifiedJulianDays().GetEnumerator();

        while (julianDayEnumerator.MoveNext() && modifiedJulianDayEnumerator.MoveNext())
        {
            var julianDay = julianDayEnumerator.Current;
            var modifiedJulianDay = modifiedJulianDayEnumerator.Current;

            yield return new object[] { julianDay[0], modifiedJulianDay[0] };
        }
    }

    public static IEnumerable<object[]> JulianDaysAndJulianDates()
    {
        var julianDayEnumerator = JulianDays().GetEnumerator();
        var julianDateEnumerator = JulianDates().GetEnumerator();

        while (julianDayEnumerator.MoveNext() && julianDateEnumerator.MoveNext())
        {
            var julianDay = julianDayEnumerator.Current;
            var julianDate = julianDateEnumerator.Current;

            yield return new object[] { julianDay[0], julianDate[0], julianDate[1], julianDate[2], julianDate[3], julianDate[4], julianDate[5] };
        }
    }

    public static IEnumerable<object[]> JulianDaysAndGregorianDates()
    {
        var julianDayEnumerator = JulianDays().GetEnumerator();
        var gregorianDateEnumerator = GregorianDates().GetEnumerator();

        while (julianDayEnumerator.MoveNext() && gregorianDateEnumerator.MoveNext())
        {
            var julianDay = julianDayEnumerator.Current;
            var gregorianDate = gregorianDateEnumerator.Current;

            yield return new object[] { julianDay[0], gregorianDate[0], gregorianDate[1], gregorianDate[2], gregorianDate[3], gregorianDate[4], gregorianDate[5] };
        }
    }

    public static IEnumerable<object[]> ModifiedJulianDaysAndJulianDates()
    {
        var modifiedJulianDayEnumerator = ModifiedJulianDays().GetEnumerator();
        var julianDateEnumerator = JulianDates().GetEnumerator();

        while (modifiedJulianDayEnumerator.MoveNext() && julianDateEnumerator.MoveNext())
        {
            var modifiedJulianDay = modifiedJulianDayEnumerator.Current;
            var julianDate = julianDateEnumerator.Current;

            yield return new object[] { modifiedJulianDay[0], julianDate[0], julianDate[1], julianDate[2], julianDate[3], julianDate[4], julianDate[5] };
        }
    }

    public static IEnumerable<object[]> ModifiedJulianDaysAndGregorianDates()
    {
        var modifiedJulianDayEnumerator = ModifiedJulianDays().GetEnumerator();
        var gregorianDateEnumerator = GregorianDates().GetEnumerator();

        while (modifiedJulianDayEnumerator.MoveNext() && gregorianDateEnumerator.MoveNext())
        {
            var modifiedJulianDay = modifiedJulianDayEnumerator.Current;
            var gregorianDate = gregorianDateEnumerator.Current;

            yield return new object[] { modifiedJulianDay[0], gregorianDate[0], gregorianDate[1], gregorianDate[2], gregorianDate[3], gregorianDate[4], gregorianDate[5] };
        }
    }

    public static IEnumerable<object[]> JulianDatesAndGregorianDates()
    {
        var julianDateEnumerator = JulianDates().GetEnumerator();
        var gregorianDateEnumerator = GregorianDates().GetEnumerator();

        while (julianDateEnumerator.MoveNext() && gregorianDateEnumerator.MoveNext())
        {
            var julianDate = julianDateEnumerator.Current;
            var gregorianDate = gregorianDateEnumerator.Current;

            yield return new object[] { julianDate[0], julianDate[1], julianDate[2], gregorianDate[0], gregorianDate[1], gregorianDate[2], julianDate[3], julianDate[4], julianDate[5] };
        }
    }
}
