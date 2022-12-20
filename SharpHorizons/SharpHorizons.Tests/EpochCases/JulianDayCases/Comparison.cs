namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;
using System.Collections.Generic;

using Xunit;

public class Comparison
{
    [Fact]
    public void JulianDayMethod_Null_Positive()
    {
        Assert.True(JulianDay.Epoch.CompareTo(null) > 0);
    }

    [Theory]
    [MemberData(nameof(ValidJulianDays))]
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
    [MemberData(nameof(ValidJulianDays))]
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
    [MemberData(nameof(ValidJulianDays))]
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
    [MemberData(nameof(ValidJulianDays))]
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
    [MemberData(nameof(ValidJulianDays))]
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
    [MemberData(nameof(ValidJulianDays))]
    public void LessThanOrEqualOperator_MatchDouble(JulianDay lhs, JulianDay rhs)
    {
        var expected = lhs.Day <= rhs.Day;
        var actual = lhs <= rhs;

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> ValidJulianDays() => new object[][]
    {
        new object[] { new JulianDay(int.MaxValue), new JulianDay(0) },
        new object[] { new JulianDay(int.MinValue), new JulianDay(0) },
        new object[] { new JulianDay(0), new JulianDay(int.MaxValue) },
        new object[] { new JulianDay(0), new JulianDay(int.MinValue) },
        new object[] { new JulianDay(-10.14), new JulianDay(10.14) },
        new object[] { new JulianDay(10.14), new JulianDay(-10.14) },
        new object[] { new JulianDay(10.14), new JulianDay(10.14) },
        new object[] { new JulianDay(-10.14), new JulianDay(-10.14) },
    };
}
