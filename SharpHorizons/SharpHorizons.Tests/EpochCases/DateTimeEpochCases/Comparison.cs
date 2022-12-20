namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Collections.Generic;

using Xunit;

public class Comparison
{
    [Fact]
    public void EpochMethod_Null_Positive()
    {
        Assert.True(DateTimeEpoch.FromJulianDay(new JulianDay(2400000)).CompareTo(null) > 0);
    }

    [Theory]
    [MemberData(nameof(ValidDateTimeEpochs))]
    public void EpochMethod_SameSignAsJulianDay(DateTimeEpoch lhs, DateTimeEpoch rhs)
    {
        var expected = Math.Sign(lhs.ToJulianDay().CompareTo(rhs.ToJulianDay()));
        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IEpochMethod_Null_Positive()
    {
        Assert.True(DateTimeEpoch.FromJulianDay(new JulianDay(2400000)).CompareTo((IEpoch?)null) > 0);
    }

    [Theory]
    [MemberData(nameof(ValidIEpochs))]
    public void IEpochMethod_SameSignAsJulianDay(DateTimeEpoch lhs, IEpoch rhs)
    {
        var expected = Math.Sign(lhs.ToJulianDay().CompareTo(rhs.ToJulianDay()));
        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreaterThanOperator_Null_False()
    {
        Assert.False(DateTimeEpoch.FromJulianDay(new JulianDay(2400000)) > null);
    }

    [Theory]
    [MemberData(nameof(ValidDateTimeEpochs))]
    public void GreaterThanOperator_MatchJulianDay(DateTimeEpoch lhs, DateTimeEpoch rhs)
    {
        var expected = lhs.ToJulianDay() > rhs.ToJulianDay();
        var actual = lhs > rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LessThanOperator_Null_False()
    {
        Assert.False(DateTimeEpoch.FromJulianDay(new JulianDay(2400000)) < null);
    }

    [Theory]
    [MemberData(nameof(ValidDateTimeEpochs))]
    public void LessThanOperator_MatchDouble(DateTimeEpoch lhs, DateTimeEpoch rhs)
    {
        var expected = lhs.ToJulianDay() < rhs.ToJulianDay();
        var actual = lhs < rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreaterThanOrEqualOperator_Null_False()
    {
        Assert.False(DateTimeEpoch.FromJulianDay(new JulianDay(2400000)) >= null);
    }

    [Theory]
    [MemberData(nameof(ValidDateTimeEpochs))]
    public void GreaterThanOrEqualOperator_MatchDouble(DateTimeEpoch lhs, DateTimeEpoch rhs)
    {
        var expected = lhs.ToJulianDay() >= rhs.ToJulianDay();
        var actual = lhs >= rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LessThanOrEqualOperator_Null_False()
    {
        Assert.False(DateTimeEpoch.FromJulianDay(new JulianDay(2400000)) <= null);
    }

    [Theory]
    [MemberData(nameof(ValidDateTimeEpochs))]
    public void LessThanOrEqualOperator_MatchDouble(DateTimeEpoch lhs, DateTimeEpoch rhs)
    {
        var expected = lhs.ToJulianDay() <= rhs.ToJulianDay();
        var actual = lhs <= rhs;

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> ValidDateTimeEpochs() => new object[][]
    {
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(4000000)), DateTimeEpoch.FromJulianDay(new JulianDay(2400000)) },
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(2400000)), DateTimeEpoch.FromJulianDay(new JulianDay(4000000)) },
    };

    public static IEnumerable<object[]> ValidIEpochs() => new object[][]
    {
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(4000000)), JulianDay.Epoch },
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(4000000)), new JulianDay(int.MaxValue) },
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(2400000)), new JulianDay(int.MinValue) },
        new object[] { DateTimeEpoch.FromJulianDay(new JulianDay(2400000)), DateTimeEpoch.FromJulianDay(new JulianDay(4000000)) },
    };
}
