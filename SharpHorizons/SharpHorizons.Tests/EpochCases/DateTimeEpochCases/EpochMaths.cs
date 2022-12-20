namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System.Collections.Generic;

using Xunit;

public class EpochMaths
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(Epochs))]
    public void DateTimeEpochMethod_ApproximateMatch(DateTimeEpoch initialEpoch, DateTimeEpoch finalEpoch)
    {
        var actual = finalEpoch.Difference(initialEpoch);

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Theory]
    [MemberData(nameof(Epochs))]
    public void DateTimeEpochOperator_ApproximateMatch(DateTimeEpoch initialEpoch, DateTimeEpoch finalEpoch)
    {
        var actual = finalEpoch - initialEpoch;

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Theory]
    [MemberData(nameof(Epochs))]
    public void IEpochMethod_ApproximateMatch(IEpoch initialEpoch, DateTimeEpoch finalEpoch)
    {
        var actual = finalEpoch.Difference(initialEpoch);

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Theory]
    [MemberData(nameof(Epochs))]
    public void IEpochOperator_ApproximateMatch(IEpoch initialEpoch, DateTimeEpoch finalEpoch)
    {
        var actual = finalEpoch - initialEpoch;

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    public static IEnumerable<object[]> Epochs() => new object[][]
    {
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)), DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)) },
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(2400001.5)), DateTimeEpoch.FromJulianDay(new JulianDay(2399999.5)) },
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(2399999.5)), DateTimeEpoch.FromJulianDay(new JulianDay(2400001.5)) },
    };
}
