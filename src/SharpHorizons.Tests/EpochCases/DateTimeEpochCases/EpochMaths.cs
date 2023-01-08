namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class EpochMaths
{
    private static int Precision { get; } = 5;

    [Theory]
    [ClassData(typeof(Datasets.DateTimeEpochsAndConvertibleIEpochs))]
    public void Method_Convertible_ApproximatelyMatchJulianDay(DateTimeEpoch finalEpoch, IEpoch initialEpoch)
    {
        var expected = finalEpoch.ToJulianDay() - initialEpoch.ToJulianDay();

        var actual = finalEpoch.Difference(initialEpoch);

        Assert.Equal(expected.Days, actual.Days, Precision);
    }

    [Theory]
    [ClassData(typeof(Datasets.DateTimeEpochsAndUnconvertibleIEpochs))]
    public void Method_Unconvertible_ArgumentException(DateTimeEpoch finalEpoch, IEpoch initialEpoch)
    {
        var exception = Record.Exception(() => finalEpoch.Difference(initialEpoch));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Method_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => Datasets.SimpleDateTimeEpoch.Difference(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoDateTimeEpochs))]
    public void Operator_ApproximatelyMatchJulianDay(DateTimeEpoch initialEpoch, DateTimeEpoch finalEpoch)
    {
        var expected = finalEpoch.ToJulianDay() - initialEpoch.ToJulianDay();

        var actual = finalEpoch - initialEpoch;

        Assert.Equal(expected.Days, actual.Days, Precision);
    }

    [Fact]
    public void Operator_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => Datasets.SimpleDateTimeEpoch - null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
