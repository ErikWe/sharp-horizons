namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class Comparison
{
    [Fact]
    public void JulianDayMethod_Null_Positive()
    {
        Assert.True(JulianDay.Epoch.CompareTo(null) > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoJulianDays))]
    public void JulianDayMethod_SameSignAsDouble(JulianDay lhs, JulianDay rhs)
    {
        var expected = Math.Sign(lhs.Day.CompareTo(rhs.Day));
        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IEpochMethod_Null_Positive()
    {
        Assert.True(JulianDay.Epoch.CompareTo((IEpoch?)null) > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoJulianDays))]
    public void IEpochMethod_SameSignAsDouble(JulianDay lhs, JulianDay rhs)
    {
        var expected = Math.Sign(lhs.Day.CompareTo(rhs.Day));
        var actual = Math.Sign(lhs.CompareTo((IEpoch)rhs));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreaterThanOperator_Null_False()
    {
        Assert.False(JulianDay.Epoch > null);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoJulianDays))]
    public void GreaterThanOperator_MatchDouble(JulianDay lhs, JulianDay rhs)
    {
        var expected = lhs.Day > rhs.Day;
        var actual = lhs > rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LessThanOperator_Null_False()
    {
        Assert.False(JulianDay.Epoch < null);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoJulianDays))]
    public void LessThanOperator_MatchDouble(JulianDay lhs, JulianDay rhs)
    {
        var expected = lhs.Day < rhs.Day;
        var actual = lhs < rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreaterThanOrEqualOperator_Null_False()
    {
        Assert.False(JulianDay.Epoch >= null);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoJulianDays))]
    public void GreaterThanOrEqualOperator_MatchDouble(JulianDay lhs, JulianDay rhs)
    {
        var expected = lhs.Day >= rhs.Day;
        var actual = lhs >= rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LessThanOrEqualOperator_Null_False()
    {
        Assert.False(JulianDay.Epoch <= null);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoJulianDays))]
    public void LessThanOrEqualOperator_MatchDouble(JulianDay lhs, JulianDay rhs)
    {
        var expected = lhs.Day <= rhs.Day;
        var actual = lhs <= rhs;

        Assert.Equal(expected, actual);
    }
}
