namespace SharpHorizons.Tests.Epoch;

using NodaTime;

using System;
using System.Collections.Generic;
using System.Globalization;

using Xunit;

/// <credit>Values are taken from an online calendar converter, Fourmilab, https://www.fourmilab.ch/documents/calendar/.</credit>
public class EpochConversions
{
    private static JulianCalendar JulianCalendar { get; } = new();
    private static GregorianCalendar GregorianCalendar { get; } = new();

    [Fact]
    public void JulianDayToModifiedJulianDayOutOfBounds()
    {
        JulianDay julianDay = new(int.MinValue, 0);

        Assert.Throws<ArgumentOutOfRangeException>(() => ModifiedJulianDay.FromJulianDay(julianDay));
    }

    [Fact]
    public void JulianDayToEpochOutOfBounds()
    {
        JulianDay belowEpoch = new(int.MinValue, 0);
        JulianDay aboveEpoch = new(int.MaxValue, 0);

        Assert.Throws<ArgumentOutOfRangeException>(() => SharpHorizons.Epoch.FromJulianDay(belowEpoch));
        Assert.Throws<ArgumentOutOfRangeException>(() => SharpHorizons.Epoch.FromJulianDay(aboveEpoch));
    }

    [Fact]
    public void JulianDayToDateTimeEpochOutOfBounds()
    {
        JulianDay belowEpoch = new(int.MinValue, 0);
        JulianDay aboveEpoch = new(int.MaxValue, 0);

        Assert.Throws<ArgumentOutOfRangeException>(() => DateTimeEpoch.FromJulianDay(belowEpoch));
        Assert.Throws<ArgumentOutOfRangeException>(() => DateTimeEpoch.FromJulianDay(aboveEpoch));
    }

    [Theory]
    [MemberData(nameof(JulianDaysAndModifiedJulianDays))]
    public void JulianDayToModifiedJulianDay(double julianDay, double modifiedJulianDay)
    {
        ModifiedJulianDay expected = new(modifiedJulianDay);

        ModifiedJulianDay actual = ModifiedJulianDay.FromJulianDay(new JulianDay(julianDay));

        AssertApproximatelyEqual(expected, actual);
    }

    [Theory]
    [MemberData(nameof(JulianDaysAndJulianDates))]
    public void JulianDayToJulianDate(double julianDayNumber, int year, int month, int day, int hour, int minute, int second, int millisecond)
    {
        JulianDay julianDay = new(julianDayNumber);

        var nodaExpected = new SharpHorizons.Epoch(new LocalDateTime(year + (year > 0 ? 0 : 1), month, day, hour, minute, second, millisecond, CalendarSystem.Julian).InUtc());
        var nodaActual = SharpHorizons.Epoch.FromJulianDay(julianDay);

        AssertApproximatelyEqual(nodaExpected, nodaActual);

        if (year > 0)
        {
            var bclExpected = new DateTimeEpoch(new DateTime(year, month, day, hour, minute, second, millisecond, JulianCalendar), TimeSpan.Zero);
            var bclActual = DateTimeEpoch.FromJulianDay(julianDay);

            AssertApproximatelyEqual(bclExpected, bclActual);
        }
    }

    [Theory]
    [MemberData(nameof(JulianDaysAndGregorianDates))]
    public void JulianDayToGregorianDate(double julianDayNumber, int year, int month, int day, int hour, int minute, int second, int millisecond)
    {
        JulianDay julianDay = new(julianDayNumber);

        var nodaExpected = new SharpHorizons.Epoch(new LocalDateTime(year, month, day, hour, minute, second, millisecond, CalendarSystem.Gregorian).InUtc());
        var nodaActual = SharpHorizons.Epoch.FromJulianDay(julianDay);

        AssertApproximatelyEqual(nodaExpected, nodaActual);

        if (year > 0)
        {
            var bclExpected = new DateTimeEpoch(new DateTime(year, month, day, hour, minute, second, millisecond, GregorianCalendar), TimeSpan.Zero);
            var bclActual = DateTimeEpoch.FromJulianDay(julianDay);

            AssertApproximatelyEqual(bclExpected, bclActual);
        }
    }

    [Theory]
    [MemberData(nameof(JulianDaysAndModifiedJulianDays))]
    public void ModifiedJulianDayToJulianDay(double julianDayNumber, double modifiedJulianDayNumber)
    {
        JulianDay expected = new(julianDayNumber);

        JulianDay actual = new ModifiedJulianDay(modifiedJulianDayNumber).ToJulianDay();

        AssertApproximatelyEqual(expected, actual);
    }

    [Theory]
    [MemberData(nameof(JulianDaysAndJulianDates))]
    public void JulianDateToJulianDay(double julianDayNumber, int year, int month, int day, int hour, int minute, int second, int millisecond)
    {
        JulianDay expected = new(julianDayNumber);

        var nodaActual = new SharpHorizons.Epoch(new LocalDateTime(year + (year > 0 ? 0 : 1), month, day, hour, minute, second, millisecond, CalendarSystem.Julian).InUtc()).ToJulianDay();

        AssertApproximatelyEqual(expected, nodaActual);

        if (year > 0)
        {
            var bclActual = new DateTimeEpoch(new DateTime(year, month, day, hour, minute, second, millisecond, JulianCalendar), TimeSpan.Zero).ToJulianDay();

            AssertApproximatelyEqual(expected, bclActual);
        }
    }

    [Theory]
    [MemberData(nameof(JulianDatesAndGregorianDates))]
    public void JulianDateToGregorianDate(int julianYear, int julianMonth, int julianDay, int gregorianYear, int gregorianMonth, int gregorianDay, int hour, int minute, int second, int millisecond)
    {
        var nodaExpected = new SharpHorizons.Epoch(new LocalDateTime(julianYear + (julianYear > 0 ? 0 : 1), julianMonth, julianDay, hour, minute, second, millisecond, CalendarSystem.Julian).InUtc());
        var nodaActual = new SharpHorizons.Epoch(new LocalDateTime(gregorianYear, gregorianMonth, gregorianDay, hour, minute, second, millisecond, CalendarSystem.Gregorian).InUtc());

        AssertApproximatelyEqual(nodaExpected, nodaActual);

        if (gregorianYear > 0)
        {
            var bclExpected = new DateTimeEpoch(new DateTime(julianYear, julianMonth, julianDay, hour, minute, second, millisecond, JulianCalendar), TimeSpan.Zero);
            var bclActual = new DateTimeEpoch(new DateTime(gregorianYear, gregorianMonth, gregorianDay, hour, minute, second, millisecond, GregorianCalendar), TimeSpan.Zero);

            AssertApproximatelyEqual(bclExpected, bclActual);
        }
    }

    [Theory]
    [MemberData(nameof(JulianDaysAndGregorianDates))]
    public void GregorianDateToJulianDay(double julianDayNumber, int year, int month, int day, int hour, int minute, int second, int millisecond)
    {
        JulianDay expected = new(julianDayNumber);

        var nodaActual = new SharpHorizons.Epoch(new LocalDateTime(year, month, day, hour, minute, second, millisecond, CalendarSystem.Gregorian).InUtc()).ToJulianDay();

        AssertApproximatelyEqual(expected, nodaActual);

        if (year > 0)
        {
            var bclActual = new DateTimeEpoch(new DateTime(year, month, day, hour, minute, second, millisecond, GregorianCalendar), TimeSpan.Zero).ToJulianDay();

            AssertApproximatelyEqual(expected, bclActual);
        }
    }

    [Theory]
    [MemberData(nameof(JulianDatesAndGregorianDates))]
    public void GregorianDateToJulianDate(int julianYear, int julianMonth, int julianDay, int gregorianYear, int gregorianMonth, int gregorianDay, int hour, int minute, int second, int millisecond)
    {
        var nodaExpected = new SharpHorizons.Epoch(new LocalDateTime(gregorianYear, gregorianMonth, gregorianDay, hour, minute, second, millisecond, CalendarSystem.Gregorian).InUtc());
        var nodaActual = new SharpHorizons.Epoch(new LocalDateTime(julianYear + (julianYear > 0 ? 0 : 1), julianMonth, julianDay, hour, minute, second, millisecond, CalendarSystem.Julian).InUtc());

        AssertApproximatelyEqual(nodaExpected, nodaActual);

        if (gregorianYear > 0)
        {
            var bclExpected = new DateTimeEpoch(new DateTime(gregorianYear, gregorianMonth, gregorianDay, hour, minute, second, millisecond, GregorianCalendar), TimeSpan.Zero);
            var bclActual = new DateTimeEpoch(new DateTime(julianYear, julianMonth, julianDay, hour, minute, second, millisecond, JulianCalendar), TimeSpan.Zero);

            AssertApproximatelyEqual(bclExpected, bclActual);
        }
    }

    private static void AssertApproximatelyEqual(JulianDay expected, JulianDay actual)
    {
        Assert.Equal(expected.Day, actual.Day, 3);
    }

    private static void AssertApproximatelyEqual(ModifiedJulianDay expected, ModifiedJulianDay actual)
    {
        Assert.Equal(expected.Day, actual.Day, 3);
    }

    private static void AssertApproximatelyEqual(SharpHorizons.Epoch expected, SharpHorizons.Epoch actual)
    {
        Assert.Equal(expected.Instant.ToJulianDate(), actual.Instant.ToJulianDate(), 3);
    }

    private static void AssertApproximatelyEqual(DateTimeEpoch expected, DateTimeEpoch actual)
    {
        Assert.Equal(expected.Offset, actual.Offset);

        Assert.True(expected.DateTime.Ticks * 1.001 > actual.DateTime.Ticks);
        Assert.True(expected.DateTime.Ticks * 0.999 < actual.DateTime.Ticks);
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
        new object[] { 5373046.4999884255 },
        new object[] { -1930342.500011574 },
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
        new object[] { 2973045.9999884255 },
        new object[] { -4330343.0000115745 },
        new object[] { -678649.05 },
        new object[] { -678557.6100000001 }
    };

    public static IEnumerable<object[]> JulianDates() => new object[][]
    {
        new object[] { -4713, 1, 1, 12, 0, 0, 0 },
        new object[] { -4713, 1, 2, 12, 0, 0, 0 },
        new object[] { -4713, 1, 2, 18, 0, 0, 0 },
        new object[] { -4713, 1, 3, 6, 0, 0, 0 },
        new object[] { -4714, 12, 30, 12, 0, 0, 0 },
        new object[] { -4714, 12, 30, 6, 0, 0, 0 },
        new object[] { -4703, 9, 25, 6, 0, 0, 0 },
        new object[] { 2022, 10, 6, 23, 59, 59, 0 },
        new object[] { 2022, 10, 7, 0, 0, 0, 0 },
        new object[] { 2022, 10, 7, 17, 16, 15, 0 },
        new object[] { 9998, 8, 7, 23, 59, 59, 0 },
        new object[] { -9998, 1, 4, 23, 59, 59, 0 },
        new object[] { -1, 10, 20, 22, 48, 0, 0 },
        new object[] { 1, 1, 20, 9, 21, 36, 0 }
    };

    public static IEnumerable<object[]> GregorianDates() => new object[][]
    {
        new object[] { -4713, 11, 24, 12, 0, 0, 0 },
        new object[] { -4713, 11, 25, 12, 0, 0, 0 },
        new object[] { -4713, 11, 25, 18, 0, 0, 0 },
        new object[] { -4713, 11, 26, 6, 0, 0, 0 },
        new object[] { -4713, 11, 22, 12, 0, 0, 0 },
        new object[] { -4713, 11, 22, 6, 0, 0, 0 },
        new object[] { -4702, 8, 18, 6, 0, 0, 0 },
        new object[] { 2022, 10, 19, 23, 59, 59, 0 },
        new object[] { 2022, 10, 20, 0, 0, 0, 0 },
        new object[] { 2022, 10, 20, 17, 16, 15, 0 },
        new object[] { 9998, 10, 19, 23, 59, 59, 0 },
        new object[] { -9998, 10, 19, 23, 59, 59, 0 },
        new object[] { 0, 10, 18, 22, 48, 0, 0 },
        new object[] { 1, 1, 18, 9, 21, 36, 0 }
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

            yield return new object[] { julianDay[0], julianDate[0], julianDate[1], julianDate[2], julianDate[3], julianDate[4], julianDate[5], julianDate[6] };
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

            yield return new object[] { julianDay[0], gregorianDate[0], gregorianDate[1], gregorianDate[2], gregorianDate[3], gregorianDate[4], gregorianDate[5], gregorianDate[6] };
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

            yield return new object[] { julianDate[0], julianDate[1], julianDate[2], gregorianDate[0], gregorianDate[1], gregorianDate[2], julianDate[3], julianDate[4], julianDate[5], julianDate[6] };
        }
    }
}
