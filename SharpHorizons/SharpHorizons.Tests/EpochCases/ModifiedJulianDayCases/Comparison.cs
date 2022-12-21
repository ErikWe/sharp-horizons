namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class Comparison
{
    [Fact]
    public void ModifiedJulianDayMethod_Null_Positive()
    {
        Assert.True(ModifiedJulianDay.Epoch.CompareTo(null) > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoConvertibleModifiedJulianDays))]
    [ClassData(typeof(Datasets.TwoUnconvertibleModifiedJulianDays))]
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
    [ClassData(typeof(Datasets.TwoConvertibleModifiedJulianDays))]
    [ClassData(typeof(Datasets.TwoUnconvertibleModifiedJulianDays))]
    public void IEpochMethod_ModifiedJulianDay_SameSignAsDouble(ModifiedJulianDay lhs, ModifiedJulianDay rhs)
    {
        var expected = Math.Sign(lhs.Day.CompareTo(rhs.Day));
        var actual = Math.Sign(lhs.CompareTo((IEpoch)rhs));

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDaysAndIEpochs))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDaysAndConvertibleIEpochs))]
    public void IEpochMethod_ConvertibleIEpoch_SameSignAsDouble(ModifiedJulianDay lhs, IEpoch rhs)
    {
        var expected = Math.Sign((lhs.Day + 2400000.5).CompareTo(rhs.ToJulianDay().Day));
        var actual = Math.Sign(lhs.CompareTo(rhs));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreaterThanOperator_Null_False()
    {
        Assert.False(ModifiedJulianDay.Epoch > null);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoConvertibleModifiedJulianDays))]
    [ClassData(typeof(Datasets.TwoUnconvertibleModifiedJulianDays))]
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
    [ClassData(typeof(Datasets.TwoConvertibleModifiedJulianDays))]
    [ClassData(typeof(Datasets.TwoUnconvertibleModifiedJulianDays))]
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
    [ClassData(typeof(Datasets.TwoConvertibleModifiedJulianDays))]
    [ClassData(typeof(Datasets.TwoUnconvertibleModifiedJulianDays))]
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
    [ClassData(typeof(Datasets.TwoConvertibleModifiedJulianDays))]
    [ClassData(typeof(Datasets.TwoUnconvertibleModifiedJulianDays))]
    public void LessThanOrEqualOperator_MatchDouble(ModifiedJulianDay lhs, ModifiedJulianDay rhs)
    {
        var expected = lhs.Day <= rhs.Day;
        var actual = lhs <= rhs;

        Assert.Equal(expected, actual);
    }
}
