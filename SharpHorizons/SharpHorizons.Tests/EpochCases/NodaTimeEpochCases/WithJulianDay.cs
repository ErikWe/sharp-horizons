namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using System;
using System.Collections.Generic;

using Xunit;

public class WithJulianDay
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(JulianDateConversions))]
    [MemberData(nameof(GregorianDateConversions))]
    public void From_Valid(JulianDay julianDay, Epoch expected)
    {
        var actual = Epoch.FromJulianDay(julianDay);

        Assert.Equal(expected.Instant.ToJulianDate(), actual.Instant.ToJulianDate(), Precision);
    }

    [Fact]
    public void From_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Epoch.FromJulianDay(null!));
    }

    [Theory]
    [ClassData(typeof(Datasets.UnconvertibleJulianDays))]
    public void From_OutOfRange_ArgumentOutOfBoundsException(JulianDay julianDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Epoch.FromJulianDay(julianDay));
    }

    [Theory]
    [MemberData(nameof(JulianDateConversions))]
    [MemberData(nameof(GregorianDateConversions))]
    public void To_Valid(JulianDay expected, Epoch epoch)
    {
        var actual = epoch.ToJulianDay();

        Assert.Equal(expected.Day, actual.Day, Precision);
    }

    public static IEnumerable<object[]> JulianDateConversions() => new object[][]
    {
        new object[] { JulianDay.Epoch, new Epoch(new LocalDateTime(-4712, 1, 1, 12, 0, 0, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(1), new Epoch(new LocalDateTime(-4712, 1, 2, 12, 0, 0, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(1.25), new Epoch(new LocalDateTime(-4712, 1, 2, 18, 0, 0, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(1.75), new Epoch(new LocalDateTime(-4712, 1, 3, 6, 0, 0, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(-2), new Epoch(new LocalDateTime(-4713, 12, 30, 12, 0, 0, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(-2.25), new Epoch(new LocalDateTime(-4713, 12, 30, 6, 0, 0, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(3919.75), new Epoch(new LocalDateTime(-4702, 9, 25, 6, 0, 0, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(2459872.499988426), new Epoch(new LocalDateTime(2022, 10, 6, 23, 59, 59, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(2459872.5), new Epoch(new LocalDateTime(2022, 10, 7, 0, 0, 0, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(2459873.2196180555), new Epoch(new LocalDateTime(2022, 10, 7, 17, 16, 15, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(5373046.4999884255), new Epoch(new LocalDateTime(9998, 8, 7, 23, 59, 59, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(-1930342.500011574), new Epoch(new LocalDateTime(-9997, 1, 4, 23, 59, 59, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(1721351.45), new Epoch(new LocalDateTime(0, 10, 20, 22, 48, 0, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
        new object[] { new JulianDay(1721442.89), new Epoch(new LocalDateTime(1, 1, 20, 9, 21, 36, 0, CalendarSystem.Julian).InUtc().ToInstant()) },
    };

    public static IEnumerable<object[]> GregorianDateConversions() => new object[][]
    {
        new object[] { JulianDay.Epoch, new Epoch(new LocalDateTime(-4713, 11, 24, 12, 0, 0, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(1), new Epoch(new LocalDateTime(-4713, 11, 25, 12, 0, 0, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(1.25), new Epoch(new LocalDateTime(-4713, 11, 25, 18, 0, 0, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(1.75), new Epoch(new LocalDateTime(-4713, 11, 26, 6, 0, 0, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(-2), new Epoch(new LocalDateTime(-4713, 11, 22, 12, 0, 0, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(-2.25), new Epoch(new LocalDateTime(-4713, 11, 22, 6, 0, 0, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(3919.75), new Epoch(new LocalDateTime(-4702, 8, 18, 6, 0, 0, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(2459872.499988426), new Epoch(new LocalDateTime(2022, 10, 19, 23, 59, 59, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(2459872.5), new Epoch(new LocalDateTime(2022, 10, 20, 0, 0, 0, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(2459873.2196180555), new Epoch(new LocalDateTime(2022, 10, 20, 17, 16, 15, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(5373046.4999884255), new Epoch(new LocalDateTime(9998, 10, 19, 23, 59, 59, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(-1930342.500011574), new Epoch(new LocalDateTime(-9998, 10, 19, 23, 59, 59, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(1721351.45), new Epoch(new LocalDateTime(0, 10, 18, 22, 48, 0, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
        new object[] { new JulianDay(1721442.89), new Epoch(new LocalDateTime(1, 1, 18, 9, 21, 36, 0, CalendarSystem.Gregorian).InUtc().ToInstant()) },
    };
}
