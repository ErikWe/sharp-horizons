namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System;

using Xunit;

public class Comparison
{
    [Fact]
    public void EpochMethod_Null_Positive()
    {
        Assert.True(Epoch.FromJulianDay(new JulianDay(0)).CompareTo(null) > 0);
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
        Assert.True(Epoch.FromJulianDay(new JulianDay(0)).CompareTo((IEpoch?)null) > 0);
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
        Assert.Throws<ArgumentException>(() => lhs.CompareTo(rhs));
    }

    [Fact]
    public void GreaterThanOperator_Null_False()
    {
        Assert.False(Epoch.FromJulianDay(new JulianDay(0)) > null);
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
        Assert.False(Epoch.FromJulianDay(new JulianDay(0)) < null);
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
        Assert.False(Epoch.FromJulianDay(new JulianDay(0)) >= null);
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
        Assert.False(Epoch.FromJulianDay(new JulianDay(0)) <= null);
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
