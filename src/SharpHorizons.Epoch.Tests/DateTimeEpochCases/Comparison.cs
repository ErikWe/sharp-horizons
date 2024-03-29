﻿namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class Comparison
{
    [Fact]
    public void EpochMethod_Null_Positive()
    {
        var comparison = Datasets.SimpleDateTimeEpoch.CompareTo(null);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoDateTimeEpochs))]
    public void EpochMethod_SameSignAsJulianDay(DateTimeEpoch lhs, DateTimeEpoch rhs)
    {
        var expected = Math.Sign(lhs.ToJulianDay().CompareTo(rhs.ToJulianDay()));

        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IEpochMethod_Null_Positive()
    {
        var comparison = Datasets.SimpleDateTimeEpoch.CompareTo((IEpoch?)null);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.DateTimeEpochsAndConvertibleIEpochs))]
    public void IEpochMethod_Convertible_SameSignAsJulianDay(DateTimeEpoch lhs, IEpoch rhs)
    {
        var expected = Math.Sign(lhs.ToJulianDay().CompareTo(rhs.ToJulianDay()));

        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.DateTimeEpochsAndUnconvertibleIEpochs))]
    public void IEpochMethod_Unconvertible_ArgumentException(DateTimeEpoch lhs, IEpoch rhs)
    {
        var exception = Record.Exception(() => lhs.CompareTo(rhs));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void GreaterThanOperator_Null_False()
    {
        var comparison = Datasets.SimpleDateTimeEpoch > null;

        Assert.False(comparison);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoDateTimeEpochs))]
    public void GreaterThanOperator_MatchJulianDay(DateTimeEpoch lhs, DateTimeEpoch rhs)
    {
        var expected = lhs.ToJulianDay() > rhs.ToJulianDay();

        var actual = lhs > rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LessThanOperator_Null_False()
    {
        var comparison = Datasets.SimpleDateTimeEpoch < null;

        Assert.False(comparison);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoDateTimeEpochs))]
    public void LessThanOperator_MatchDouble(DateTimeEpoch lhs, DateTimeEpoch rhs)
    {
        var expected = lhs.ToJulianDay() < rhs.ToJulianDay();

        var actual = lhs < rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreaterThanOrEqualOperator_Null_False()
    {
        var comparison = Datasets.SimpleDateTimeEpoch >= null;

        Assert.False(comparison);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoDateTimeEpochs))]
    public void GreaterThanOrEqualOperator_MatchDouble(DateTimeEpoch lhs, DateTimeEpoch rhs)
    {
        var expected = lhs.ToJulianDay() >= rhs.ToJulianDay();

        var actual = lhs >= rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LessThanOrEqualOperator_Null_False()
    {
        var comparison = Datasets.SimpleDateTimeEpoch <= null;

        Assert.False(comparison);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoDateTimeEpochs))]
    public void LessThanOrEqualOperator_MatchDouble(DateTimeEpoch lhs, DateTimeEpoch rhs)
    {
        var expected = lhs.ToJulianDay() <= rhs.ToJulianDay();

        var actual = lhs <= rhs;

        Assert.Equal(expected, actual);
    }
}
