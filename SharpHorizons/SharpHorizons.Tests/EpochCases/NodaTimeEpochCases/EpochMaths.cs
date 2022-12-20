namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System.Collections.Generic;

using Xunit;

public class EpochMaths
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(Epochs))]
    public void EpochMethod_ApproximateMatch(Epoch initialEpoch, Epoch finalEpoch)
    {
        var actual = finalEpoch.Difference(initialEpoch);

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Theory]
    [MemberData(nameof(Epochs))]
    public void EpochOperator_ApproximateMatch(Epoch initialEpoch, Epoch finalEpoch)
    {
        var actual = finalEpoch - initialEpoch;

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Theory]
    [MemberData(nameof(Epochs))]
    public void IEpochMethod_ApproximateMatch(IEpoch initialEpoch, Epoch finalEpoch)
    {
        var actual = finalEpoch.Difference(initialEpoch);

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Theory]
    [MemberData(nameof(Epochs))]
    public void IEpochOperator_ApproximateMatch(IEpoch initialEpoch, Epoch finalEpoch)
    {
        var actual = finalEpoch - initialEpoch;

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    public static IEnumerable<object[]> Epochs() => new object[][]
    {
        new object[] { Epoch.FromJulianDay(new JulianDay(0)), Epoch.FromJulianDay(new JulianDay(0)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(1)), Epoch.FromJulianDay(new JulianDay(-1)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(-1)), Epoch.FromJulianDay(new JulianDay(1)) },
    };
}
