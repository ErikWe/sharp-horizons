namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Collections.Generic;
using System.Globalization;

using Xunit;

public class WithJulianDay
{
    private static JulianCalendar JulianCalendar { get; } = new();
    private static GregorianCalendar GregorianCalendar { get; } = new();
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(JulianDateConversions))]
    [MemberData(nameof(GregorianDateConversions))]
    public void From_Valid(JulianDay julianDay, DateTimeEpoch expected)
    {
        var actual = DateTimeEpoch.FromJulianDay(julianDay);

        Assert.InRange(actual.DateTimeOffset.Ticks, expected.DateTimeOffset.Ticks * 0.99999, expected.DateTimeOffset.Ticks * 1.00001);
    }

    [Fact]
    public void From_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => DateTimeEpoch.FromJulianDay(null!));
    }

    [Theory]
    [MemberData(nameof(InvalidJulianDays))]
    public void From_OutOfRange_ArgumentOutOfBoundsException(JulianDay julianDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => DateTimeEpoch.FromJulianDay(julianDay));
    }

    [Theory]
    [MemberData(nameof(JulianDateConversions))]
    [MemberData(nameof(GregorianDateConversions))]
    public void To_Valid(JulianDay expected, DateTimeEpoch epoch)
    {
        var actual = epoch.ToJulianDay();

        Assert.Equal(expected.Day, actual.Day, Precision);
    }

    public static IEnumerable<object[]> JulianDateConversions() => new object[][]
    {
        new object[] { new JulianDay(2459872.499988426), new DateTimeEpoch(new DateTime(2022, 10, 6, 23, 59, 59, 0, JulianCalendar, DateTimeKind.Unspecified), TimeSpan.Zero) },
        new object[] { new JulianDay(2459872.5), new DateTimeEpoch(new DateTime(2022, 10, 7, 0, 0, 0, 0, JulianCalendar, DateTimeKind.Unspecified), TimeSpan.Zero) },
        new object[] { new JulianDay(2459873.2196180555), new DateTimeEpoch(new DateTime(2022, 10, 7, 17, 16, 15, 0, JulianCalendar, DateTimeKind.Unspecified), TimeSpan.Zero) },
        new object[] { new JulianDay(5373046.4999884255), new DateTimeEpoch(new DateTime(9998, 8, 7, 23, 59, 59, 0, JulianCalendar, DateTimeKind.Unspecified), TimeSpan.Zero) },
        new object[] { new JulianDay(1721442.89), new DateTimeEpoch(new DateTime(1, 1, 20, 9, 21, 36, 0, JulianCalendar, DateTimeKind.Unspecified), TimeSpan.Zero) },
    };

    public static IEnumerable<object[]> GregorianDateConversions() => new object[][]
    {
        new object[] { new JulianDay(2459872.499988426), new DateTimeEpoch(new DateTime(2022, 10, 19, 23, 59, 59, 0, GregorianCalendar, DateTimeKind.Unspecified), TimeSpan.Zero) },
        new object[] { new JulianDay(2459872.5), new DateTimeEpoch(new DateTime(2022, 10, 20, 0, 0, 0, 0, GregorianCalendar, DateTimeKind.Unspecified), TimeSpan.Zero) },
        new object[] { new JulianDay(2459873.2196180555), new DateTimeEpoch(new DateTime(2022, 10, 20, 17, 16, 15, 0, GregorianCalendar, DateTimeKind.Unspecified), TimeSpan.Zero) },
        new object[] { new JulianDay(5373046.4999884255), new DateTimeEpoch(new DateTime(9998, 10, 19, 23, 59, 59, 0, GregorianCalendar, DateTimeKind.Unspecified), TimeSpan.Zero) },
        new object[] { new JulianDay(1721442.89), new DateTimeEpoch(new DateTime(1, 1, 18, 9, 21, 36, 0, GregorianCalendar, DateTimeKind.Unspecified), TimeSpan.Zero) },
    };

    public static IEnumerable<object[]> InvalidJulianDays() => new object[][]
    {
        new object[] { new JulianDay(int.MaxValue) },
        new object[] { new JulianDay(int.MinValue) },
        new object[] { new JulianDay(0) }
    };
}
