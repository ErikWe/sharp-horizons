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
        var expected = finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day;

        var actual = finalEpoch.Difference(initialEpoch);

        Assert.Equal(expected, actual.Days, TimePrecision);
    }

    [Theory]
    [ClassData(typeof(Datasets.EpochsAndUnconvertibleIEpochs))]
    public void Method_Unconvertible_ApproximateMatch(Epoch finalEpoch, IEpoch initialEpoch)
    {
        var exception = Record.Exception(() => finalEpoch.Difference(initialEpoch));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Method_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => Epoch.FromJulianDay(JulianDay.Epoch).Difference(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoEpochs))]
    public void Operator_ApproximateMatch(Epoch initialEpoch, Epoch finalEpoch)
    {
        var expected = finalEpoch.ToJulianDay().Day - initialEpoch.ToJulianDay().Day;

        var actual = finalEpoch - initialEpoch;

        Assert.Equal(expected, actual.Days, TimePrecision);
    }

    [Fact]
    public void Operator_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => Epoch.FromJulianDay(JulianDay.Epoch) - null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
