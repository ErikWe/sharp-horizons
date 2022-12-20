namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;
using System.Collections.Generic;

using Xunit;

public class Comparison
{
    [Fact]
    public void ModifiedJulianDayMethod_Null_Positive()
    {
        Assert.True(ModifiedJulianDay.Epoch.CompareTo(null) > 0);
    }

    [Theory]
    [MemberData(nameof(ValidModifiedJulianDays))]
    public void ModifiedJulianDayMethod_SameSignAsDouble(ModifiedJulianDay lhs, ModifiedJulianDay rhs)
    {
        var expected = Math.Sign(lhs.Day.CompareTo(rhs.Day));
        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IEpochMethod_Null_Positive()
    {
        Assert.True(ModifiedJulianDay.Epoch.CompareTo((IEpoch?)null) > 0);
    }

    [Theory]
    [MemberData(nameof(ValidIEpochs))]
    public void IEpochMethod_SameSignAsDouble(ModifiedJulianDay lhs, IEpoch rhs)
    {
        var expected = Math.Sign((lhs.Day + 2400000.5).CompareTo(rhs.ToJulianDay().Day));
        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(InvalidModifiedJulianDays))]
    public void IEpochMethod_OutOfRange_ArgumentException(ModifiedJulianDay rhs)
    {
        Assert.Throws<ArgumentException>(() => ModifiedJulianDay.Epoch.CompareTo((IEpoch)rhs));
    }

    [Fact]
    public void GreaterThanOperator_Null_False()
    {
        Assert.False(ModifiedJulianDay.Epoch > null);
    }

    [Theory]
    [MemberData(nameof(ValidModifiedJulianDays))]
    public void GreaterThanOperator_MatchDouble(ModifiedJulianDay lhs, ModifiedJulianDay rhs)
    {
        var expected = lhs.Day > rhs.Day;
        var actual = lhs > rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LessThanOperator_Null_False()
    {
        Assert.False(ModifiedJulianDay.Epoch < null);
    }

    [Theory]
    [MemberData(nameof(ValidModifiedJulianDays))]
    public void LessThanOperator_MatchDouble(ModifiedJulianDay lhs, ModifiedJulianDay rhs)
    {
        var expected = lhs.Day < rhs.Day;
        var actual = lhs < rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreaterThanOrEqualOperator_Null_False()
    {
        Assert.False(ModifiedJulianDay.Epoch >= null);
    }

    [Theory]
    [MemberData(nameof(ValidModifiedJulianDays))]
    public void GreaterThanOrEqualOperator_MatchDouble(ModifiedJulianDay lhs, ModifiedJulianDay rhs)
    {
        var expected = lhs.Day >= rhs.Day;
        var actual = lhs >= rhs;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LessThanOrEqualOperator_Null_False()
    {
        Assert.False(ModifiedJulianDay.Epoch <= null);
    }

    [Theory]
    [MemberData(nameof(ValidModifiedJulianDays))]
    public void LessThanOrEqualOperator_MatchDouble(ModifiedJulianDay lhs, ModifiedJulianDay rhs)
    {
        var expected = lhs.Day <= rhs.Day;
        var actual = lhs <= rhs;

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> ValidModifiedJulianDays() => new object[][]
    {
        new object[] { new ModifiedJulianDay(int.MaxValue), new ModifiedJulianDay(0) },
        new object[] { new ModifiedJulianDay(int.MinValue), new ModifiedJulianDay(0) },
        new object[] { new ModifiedJulianDay(0), new ModifiedJulianDay(int.MaxValue) },
        new object[] { new ModifiedJulianDay(0), new ModifiedJulianDay(int.MinValue) },
        new object[] { new ModifiedJulianDay(-10.14), new ModifiedJulianDay(10.14) },
        new object[] { new ModifiedJulianDay(10.14), new ModifiedJulianDay(-10.14) },
        new object[] { new ModifiedJulianDay(10.14), new ModifiedJulianDay(10.14) },
        new object[] { new ModifiedJulianDay(-10.14), new ModifiedJulianDay(-10.14) },
    };

    public static IEnumerable<object[]> ValidIEpochs() => new object[][]
    {
        new object[] { new ModifiedJulianDay(int.MaxValue), JulianDay.Epoch },
        new object[] { new ModifiedJulianDay(int.MinValue), new JulianDay(int.MaxValue) },
        new object[] { new ModifiedJulianDay(0), new JulianDay(int.MinValue) },
        new object[] { new ModifiedJulianDay(0), new ModifiedJulianDay(int.MinValue) },
        new object[] { new ModifiedJulianDay(-10.14), new ModifiedJulianDay(10.14) },
        new object[] { new ModifiedJulianDay(10.14), new ModifiedJulianDay(-10.14) },
        new object[] { new ModifiedJulianDay(10.14), new ModifiedJulianDay(10.14) },
        new object[] { new ModifiedJulianDay(-10.14), new ModifiedJulianDay(-10.14) },
    };

    public static IEnumerable<object[]> InvalidModifiedJulianDays() => new object[][]
    {
        new object[] { new ModifiedJulianDay(int.MaxValue) }
    };
}
