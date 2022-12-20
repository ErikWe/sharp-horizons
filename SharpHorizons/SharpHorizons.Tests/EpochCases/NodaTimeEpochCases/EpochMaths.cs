namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System;
using System.Collections.Generic;

using Xunit;

public class EpochMaths
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(Epochs))]
    public void Method_ApproximateMatch(Epoch initialEpoch, Epoch finalEpoch)
    {
        var actual = finalEpoch.Difference(initialEpoch);

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Fact]
    public void Method_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Epoch.FromJulianDay(new JulianDay(0)).Difference(null!));
    }

    [Theory]
    [MemberData(nameof(Epochs))]
    public void Operator_ApproximateMatch(Epoch initialEpoch, Epoch finalEpoch)
    {
        var actual = finalEpoch - initialEpoch;

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Fact]
    public void Operator_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Epoch.FromJulianDay(new JulianDay(0)) - null!);
    }

    public static IEnumerable<object[]> Epochs() => new object[][]
    {
        new object[] { Epoch.FromJulianDay(new JulianDay(0)), Epoch.FromJulianDay(new JulianDay(0)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(1)), Epoch.FromJulianDay(new JulianDay(-1)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(-1)), Epoch.FromJulianDay(new JulianDay(1)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(0)), Epoch.FromJulianDay(new JulianDay(-1000000)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(0)), Epoch.FromJulianDay(new JulianDay(1000000)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(1000000)), Epoch.FromJulianDay(new JulianDay(0)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(1000000)), Epoch.FromJulianDay(new JulianDay(-1000000)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(1000000)), Epoch.FromJulianDay(new JulianDay(1000000)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(-1000000)), Epoch.FromJulianDay(new JulianDay(-1000000)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(-1000000)), Epoch.FromJulianDay(new JulianDay(1000000)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(-1000000)), Epoch.FromJulianDay(new JulianDay(0)) }
    };
}
