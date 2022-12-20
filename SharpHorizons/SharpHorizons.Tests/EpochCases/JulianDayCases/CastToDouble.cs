namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;
using System.Collections.Generic;

using Xunit;

public class CastToDouble
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(Combined_Valid))]
    public void Valid_ApproximateMatch(JulianDay julianDay)
    {
        var actual = (double)julianDay;

        Assert.Equal(julianDay.Day, actual, Precision);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => (double)(JulianDay)null!);
    }

    public static IEnumerable<object[]> Combined_Valid() => new object[][]
    {
        new object[] { new JulianDay(int.MaxValue + 0.99) },
        new object[] { new JulianDay((double)int.MinValue) },
        new object[] { JulianDay.Epoch },
        new object[] { new JulianDay(-10.14) },
        new object[] { new JulianDay(10.14) }
    };
}
