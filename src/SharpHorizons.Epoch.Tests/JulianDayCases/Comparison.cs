﻿namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class Comparison
{
    [Fact]
    public void JulianDayMethod_Null_Positive()
    {
        var comparison = JulianDay.Epoch.CompareTo(null);

        Assert.True(comparison > 0);
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
        var comparison = JulianDay.Epoch.CompareTo((IEpoch?)null);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoJulianDays))]
    public void IEpochMethod_SameSignAsDouble(JulianDay lhs, IEpoch rhs)
    {
        var expected = Math.Sign(lhs.Day.CompareTo(rhs.ToJulianDay().Day));

        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreaterThanOperator_Null_False()
    {
        var comparison = JulianDay.Epoch > null;

        Assert.False(comparison);
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
        var comparison = JulianDay.Epoch < null;

        Assert.False(comparison);
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
        var comparison = JulianDay.Epoch >= null;

        Assert.False(comparison);
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
        var comparison = JulianDay.Epoch <= null;

        Assert.False(comparison);
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
