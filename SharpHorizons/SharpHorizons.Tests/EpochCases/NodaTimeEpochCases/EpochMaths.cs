namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System;

using Xunit;

public class EpochMaths
{
    private static int TimePrecision { get; } = 5;

    [Theory]
    [ClassData(typeof(Datasets.EpochsAndConvertibleIEpochs))]
    public void Method_Convertible_ApproximateMatch(Epoch finalEpoch, IEpoch initialEpoch)
    {
        var actual = finalEpoch.Difference(initialEpoch);

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, TimePrecision);
    }

    [Theory]
    [ClassData(typeof(Datasets.EpochsAndUnconvertibleIEpochs))]
    public void Method_Unconvertible_ApproximateMatch(Epoch finalEpoch, IEpoch initialEpoch)
    {
        Assert.Throws<ArgumentException>(() => finalEpoch.Difference(initialEpoch));
    }

    [Fact]
    public void Method_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Epoch.FromJulianDay(new JulianDay(0)).Difference(null!));
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoEpochs))]
    public void Operator_ApproximateMatch(Epoch initialEpoch, Epoch finalEpoch)
    {
        var actual = finalEpoch - initialEpoch;

        Assert.Equal(finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, TimePrecision);
    }

    [Fact]
    public void Operator_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Epoch.FromJulianDay(new JulianDay(0)) - null!);
    }
}
