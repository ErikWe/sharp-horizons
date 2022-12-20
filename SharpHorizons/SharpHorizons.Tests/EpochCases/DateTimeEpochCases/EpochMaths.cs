namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Collections.Generic;

using Xunit;

public class EpochMaths
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(Epochs))]
    public void Method_ApproximateMatch(DateTimeEpoch initialEpoch, DateTimeEpoch finalEpoch)
    {
        var actual = finalEpoch.Difference(initialEpoch);

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Fact]
    public void Method_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)).Difference(null!));
    }

    [Theory]
    [MemberData(nameof(Epochs))]
    public void Operator_ApproximateMatch(DateTimeEpoch initialEpoch, DateTimeEpoch finalEpoch)
    {
        var actual = finalEpoch - initialEpoch;

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Fact]
    public void Operator_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)) - null!);
    }

    public static IEnumerable<object[]> Epochs() => new object[][]
    {
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)), DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)) },
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(2400001.5)), DateTimeEpoch.FromJulianDay(new JulianDay(2399999.5)) },
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(2399999.5)), DateTimeEpoch.FromJulianDay(new JulianDay(2400001.5)) },
    };
}
