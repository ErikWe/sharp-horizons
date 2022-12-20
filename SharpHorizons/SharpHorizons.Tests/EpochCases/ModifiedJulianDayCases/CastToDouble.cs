namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;
using System.Collections.Generic;

using Xunit;

public class CastToDouble
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(Combined_Valid))]
    public void Valid_ApproximateMatch(ModifiedJulianDay modifiedJulianDay)
    {
        var actual = (double)modifiedJulianDay;

        Assert.Equal(modifiedJulianDay.Day, actual, Precision);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => (double)(ModifiedJulianDay)null!);
    }

    public static IEnumerable<object[]> Combined_Valid() => new object[][]
    {
        new object[] { new ModifiedJulianDay(int.MaxValue - 2400000.01) },
        new object[] { new ModifiedJulianDay((double)int.MinValue) },
        new object[] { ModifiedJulianDay.Epoch },
        new object[] { new ModifiedJulianDay(-10.14) },
        new object[] { new ModifiedJulianDay(10.14) }
    };
}
