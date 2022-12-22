namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System;

using Xunit;

public class Comparison
{
    [Fact]
    public void EpochMethod_Null_Positive()
    {
        var comparison = Epoch.FromJulianDay(JulianDay.Epoch).CompareTo(null);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoEpochs))]
    public void EpochMethod_SameSignAsJulianDay(Epoch lhs, Epoch rhs)
    {
        var expected = Math.Sign(lhs.ToJulianDay().CompareTo(rhs.ToJulianDay()));

        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IEpochMethod_Null_Positive()
    {
        var comparison = Epoch.FromJulianDay(JulianDay.Epoch).CompareTo((IEpoch?)null);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.EpochsAndConvertibleIEpochs))]
    public void IEpochMethod_Convertible_SameSignAsJulianDay(Epoch lhs, IEpoch rhs)
    {
        var expected = Math.Sign(lhs.ToJulianDay().CompareTo(rhs.ToJulianDay()));

        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.EpochsAndUnconvertibleIEpochs))]
    public void IEpochMethod_Unconvertible_ArgumentException(Epoch lhs, IEpoch rhs)
    {
        var exception = Record.Exception(() => lhs.CompareTo(rhs));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void GreaterThanOperator_Null_False()
    {
        var comparison = Epoch.FromJulianDay(JulianDay.Epoch) > null;

        Assert.False(comparison);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoEpochs))]
    public void GreaterThanOperator_MatchJulianDay(Epoch lhs, Epoch rhs)
    {
        var expected = lhs.ToJulianDay() > rhs.ToJulianDay();

        var actual = lhs > rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LessThanOperator_Null_False()
    {
        var comparison = Epoch.FromJulianDay(JulianDay.Epoch) < null;

        Assert.False(comparison);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoEpochs))]
    public void LessThanOperator_MatchDouble(Epoch lhs, Epoch rhs)
    {
        var expected = lhs.ToJulianDay() < rhs.ToJulianDay();

        var actual = lhs < rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreaterThanOrEqualOperator_Null_False()
    {
        var comparison = Epoch.FromJulianDay(JulianDay.Epoch) >= null;

        Assert.False(comparison);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoEpochs))]
    public void GreaterThanOrEqualOperator_MatchDouble(Epoch lhs, Epoch rhs)
    {
        var expected = lhs.ToJulianDay() >= rhs.ToJulianDay();

        var actual = lhs >= rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LessThanOrEqualOperator_Null_False()
    {
        var comparison = Epoch.FromJulianDay(JulianDay.Epoch) <= null;

        Assert.False(comparison);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoEpochs))]
    public void LessThanOrEqualOperator_MatchDouble(Epoch lhs, Epoch rhs)
    {
        var expected = lhs.ToJulianDay() <= rhs.ToJulianDay();

        var actual = lhs <= rhs;

        Assert.Equal(expected, actual);
    }
}
