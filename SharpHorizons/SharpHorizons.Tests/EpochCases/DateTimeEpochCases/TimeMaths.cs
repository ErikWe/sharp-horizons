namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using SharpMeasures;

using System;
using System.Collections.Generic;

using Xunit;

public class TimeMaths
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void AddMethod_Invalid_ArgumentException(Time difference)
    {
        Assert.Throws<ArgumentException>(() => DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)).Add(difference));
    }

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void AddOperator_Invalid_ArgumentException(Time difference)
    {
        Assert.Throws<ArgumentException>(() => DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)) + difference);
    }

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void SubtractOperator_Invalid_ArgumentException(Time difference)
    {
        Assert.Throws<ArgumentException>(() => DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)) - difference);
    }

    [Fact]
    public void AddMethod_OutOfBounds_EpochOutOfBoundsException()
    {
        Time difference = new(double.MaxValue);

        Assert.Throws<EpochOutOfBoundsException>(() => DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)).Add(difference));
    }

    [Fact]
    public void AddOperator_OutOfBounds_EpochOutOfBoundsException()
    {
        Time difference = new(double.MaxValue);

        Assert.Throws<EpochOutOfBoundsException>(() => DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)) + difference);
    }

    [Fact]
    public void SubtractOperator_OutOfBounds_EpochOutOfBoundsException()
    {
        Time difference = new(double.MaxValue);

        Assert.Throws<EpochOutOfBoundsException>(() => DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)) - difference);
    }

    [Theory]
    [MemberData(nameof(ValidTimes))]
    public void AddMethod_ApproximateMatch(Time difference)
    {
        var actual = DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)).Add(difference);

        Assert.Equal(2400000.5 + difference.Days, actual.ToJulianDay().Day, Precision);
    }

    [Theory]
    [MemberData(nameof(ValidTimes))]
    public void AddOperator_ApproximateMatch(Time difference)
    {
        var actual = DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)) + difference;

        Assert.Equal(2400000.5 + difference.Days, actual.ToJulianDay().Day, Precision);
    }

    [Theory]
    [MemberData(nameof(ValidTimes))]
    public void SubtractOperator_ApproximateMatch(Time difference)
    {
        var actual = DateTimeEpoch.FromJulianDay(new JulianDay(2400000.5)) - difference;

        Assert.Equal(2400000.5 - difference.Days, actual.ToJulianDay().Day, Precision);
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
