namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Collections.Generic;
using System.Globalization;

using Xunit;

public class Construction
{
    private static JulianCalendar JulianCalendar { get; } = new();
    private static GregorianCalendar GregorianCalendar { get; } = new();

    [Theory]
    [MemberData(nameof(ValidDateTimeOffsets))]
    public void Constructor_Combined_Valid(DateTimeOffset offset)
    {
        DateTimeEpoch epoch = new(offset);

        Assert.Equal(offset, epoch.DateTimeOffset);
    }

    [Theory]
    [MemberData(nameof(ValidDateTimeOffsets))]
    public void Constructor_Partwise_Valid(DateTimeOffset offset)
    {
        DateTimeEpoch epoch = new(offset.DateTime, offset.Offset);

        Assert.Equal(offset, epoch.DateTimeOffset);
    }

    [Theory]
    [MemberData(nameof(ValidDateTimeOffsets))]
    public void Initialization_Combined_Valid(DateTimeOffset offset)
    {
        DateTimeEpoch epoch = new() { DateTimeOffset = offset };

        Assert.Equal(offset, epoch.DateTimeOffset);
    }

    [Theory]
    [MemberData(nameof(ValidDateTimeOffsets))]
    public void CastFromOffset_Valid(DateTimeOffset offset)
    {
        var epoch = (DateTimeEpoch)offset;

        Assert.Equal(offset, epoch.DateTimeOffset);
    }

    public static IEnumerable<object[]> ValidDateTimeOffsets() => new object[][]
    {
        new object[] { new DateTimeOffset(new DateTime(5, 1, 1, 0, 0, 0, 0, JulianCalendar), TimeSpan.Zero) },
        new object[] { new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, JulianCalendar), TimeSpan.Zero) },
        new object[] { new DateTimeOffset(new DateTime(9999, 1, 1, 0, 0, 0, 0, JulianCalendar), TimeSpan.Zero) },
        new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, GregorianCalendar), TimeSpan.Zero) },
        new object[] { new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, GregorianCalendar), TimeSpan.Zero) },
        new object[] { new DateTimeOffset(new DateTime(9999, 1, 1, 0, 0, 0, 0, GregorianCalendar), TimeSpan.Zero) },
    };
}
