namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using SharpMeasures;

using System;
using System.Collections.Generic;

using Xunit;

public class TimeMaths
{
    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void AddMethod_Invalid_ArgumentException(Time difference)
    {
        Assert.Throws<ArgumentException>(() => JulianDay.Epoch.Add(difference));
    }

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void SubtractMethod_Invalid_ArgumentException(Time difference)
    {
        Assert.Throws<ArgumentException>(() => JulianDay.Epoch.Subtract(difference));
    }

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void AddOperator_Invalid_ArgumentException(Time difference)
    {
        Assert.Throws<ArgumentException>(() => JulianDay.Epoch + difference);
    }

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void SubtractOperator_Invalid_ArgumentException(Time difference)
    {
        Assert.Throws<ArgumentException>(() => JulianDay.Epoch - difference);
    }

    [Fact]
    public void AddMethod_OutOfBounds_EpochOutOfBoundsException()
    {
        Time difference = new(double.MaxValue);

        Assert.Throws<EpochOutOfBoundsException>(() => JulianDay.Epoch.Add(difference));
    }

    [Fact]
    public void SubtractMethod_OutOfBounds_EpochOutOfBoundsException()
    {
        Time difference = new(double.MaxValue);

        Assert.Throws<EpochOutOfBoundsException>(() => JulianDay.Epoch.Subtract(difference));
    }

    [Fact]
    public void AddOperator_OutOfBounds_EpochOutOfBoundsException()
    {
        Time difference = new(double.MaxValue);

        Assert.Throws<EpochOutOfBoundsException>(() => JulianDay.Epoch + difference);
    }

    [Fact]
    public void SubtractOperator_OutOfBounds_EpochOutOfBoundsException()
    {
        Time difference = new(double.MaxValue);

        Assert.Throws<EpochOutOfBoundsException>(() => JulianDay.Epoch - difference);
    }

    [Theory]
    [MemberData(nameof(ValidTimes))]
    public void AddMethod_ApproximateMatch(Time difference)
    {
        var actual = JulianDay.Epoch.Add(difference);

        Asserter.Approximate(difference.Days, actual.Day);
    }

    [Theory]
    [MemberData(nameof(ValidTimes))]
    public void SubtractMethod_ApproximateMatch(Time difference)
    {
        var actual = JulianDay.Epoch.Subtract(difference);

        Asserter.Approximate(-difference.Days, actual.Day);
    }

    [Theory]
    [MemberData(nameof(ValidTimes))]
    public void AddOperator_ApproximateMatch(Time difference)
    {
        var actual = JulianDay.Epoch + difference;

        Asserter.Approximate(difference.Days, actual.Day);
    }

    [Theory]
    [MemberData(nameof(ValidTimes))]
    public void SubtractOperator_ApproximateMatch(Time difference)
    {
        var actual = JulianDay.Epoch - difference;

        Asserter.Approximate(-difference.Days, actual.Day);
    }

    public static IEnumerable<object[]> ValidTimes() => new object[][]
    {
        new object[] { Time.OneDay * 2.5 },
        new object[] { Time.OneDay * 0.314 }
    };

    public static IEnumerable<object[]> InvalidTimes() => new object[][]
    {
        new object[] { new Time(double.NaN) },
        new object[] { new Time(double.NegativeInfinity) },
        new object[] { new Time(double.PositiveInfinity) }
    };
}
