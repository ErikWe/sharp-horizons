namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Collections.Generic;
using System.Globalization;

using Xunit;

public class CastToDateTimeOffset
{
    private static JulianCalendar JulianCalendar { get; } = new();
    private static GregorianCalendar GregorianCalendar { get; } = new();

    [Theory]
    [MemberData(nameof(DateTimeOffsets))]
    public void Valid(DateTimeOffset offset)
    {
        var epoch = (DateTimeEpoch)offset;

        Assert.Equal(offset, epoch.DateTimeOffset);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => (DateTimeOffset)(DateTimeEpoch)null!);
    }

    public static IEnumerable<object[]> DateTimeOffsets() => new object[][]
    {
        new object[] { new DateTimeOffset(new DateTime(5, 1, 1, 0, 0, 0, 0, JulianCalendar), TimeSpan.Zero) },
        new object[] { new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, JulianCalendar), TimeSpan.Zero) },
        new object[] { new DateTimeOffset(new DateTime(9999, 1, 1, 0, 0, 0, 0, JulianCalendar), TimeSpan.Zero) },
        new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, GregorianCalendar), TimeSpan.Zero) },
        new object[] { new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, GregorianCalendar), TimeSpan.Zero) },
        new object[] { new DateTimeOffset(new DateTime(9999, 1, 1, 0, 0, 0, 0, GregorianCalendar), TimeSpan.Zero) },
    };
}
