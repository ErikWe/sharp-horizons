namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System;
using System.Collections.Generic;

using Xunit;

public class Comparison
{
    [Fact]
    public void EpochMethod_Null_Positive()
    {
        Assert.True(Epoch.FromJulianDay(new JulianDay(0)).CompareTo(null) > 0);
    }

    [Theory]
    [MemberData(nameof(ValidEpochs))]
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
    [MemberData(nameof(ValidIEpochs))]
    public void IEpochMethod_SameSignAsJulianDay(Epoch lhs, IEpoch rhs)
    {
        var expected = Math.Sign(lhs.ToJulianDay().CompareTo(rhs.ToJulianDay()));
        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreaterThanOperator_Null_False()
    {
        Assert.False(Epoch.FromJulianDay(new JulianDay(0)) > null);
    }

    [Theory]
    [MemberData(nameof(ValidEpochs))]
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
    [MemberData(nameof(ValidEpochs))]
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
    [MemberData(nameof(ValidEpochs))]
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
    [MemberData(nameof(ValidEpochs))]
    public void LessThanOrEqualOperator_MatchDouble(Epoch lhs, Epoch rhs)
    {
        var expected = lhs.ToJulianDay() <= rhs.ToJulianDay();
        var actual = lhs <= rhs;

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> ValidEpochs() => new object[][]
    {
        new object[] { Epoch.FromJulianDay(new JulianDay(1000000)), Epoch.FromJulianDay(new JulianDay(0)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(-1000000)), Epoch.FromJulianDay(new JulianDay(0)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(0)), Epoch.FromJulianDay(new JulianDay(1000000)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(0)), Epoch.FromJulianDay(new JulianDay(-1000000)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(-10.14)), Epoch.FromJulianDay(new JulianDay(10.14)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(10.14)), Epoch.FromJulianDay(new JulianDay(-10.14)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(10.14)), Epoch.FromJulianDay(new JulianDay(10.14)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(-10.14)), Epoch.FromJulianDay(new JulianDay(-10.14)) },
    };

    public static IEnumerable<object[]> ValidIEpochs() => new object[][]
    {
        new object[] { Epoch.FromJulianDay(new JulianDay(1000000)), JulianDay.Epoch },
        new object[] { Epoch.FromJulianDay(new JulianDay(-1000000)), new JulianDay(int.MaxValue) },
        new object[] { Epoch.FromJulianDay(new JulianDay(0)), new JulianDay(int.MinValue) },
        new object[] { Epoch.FromJulianDay(new JulianDay(0)), Epoch.FromJulianDay(new JulianDay(-1000000)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(-10.14)), Epoch.FromJulianDay(new JulianDay(10.14)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(10.14)), Epoch.FromJulianDay(new JulianDay(-10.14)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(10.14)), Epoch.FromJulianDay(new JulianDay(10.14)) },
        new object[] { Epoch.FromJulianDay(new JulianDay(-10.14)), Epoch.FromJulianDay(new JulianDay(-10.14)) },
    };
}
