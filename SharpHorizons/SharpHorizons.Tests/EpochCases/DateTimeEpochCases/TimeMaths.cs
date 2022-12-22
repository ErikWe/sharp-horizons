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
        var exception = Record.Exception(() => Datasets.SimpleDateTimeEpoch.Add(difference));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void AddOperator_Invalid_ArgumentException(Time difference)
    {
        var exception = Record.Exception(() => Datasets.SimpleDateTimeEpoch + difference);

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void SubtractOperator_Invalid_ArgumentException(Time difference)
    {
        var exception = Record.Exception(() => Datasets.SimpleDateTimeEpoch - difference);

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void AddMethod_OutOfBounds_EpochOutOfBoundsException()
    {
        Time difference = new(double.MaxValue);

        var exception = Record.Exception(() => Datasets.SimpleDateTimeEpoch.Add(difference));

        Assert.IsType<EpochOutOfBoundsException>(exception);
    }

    [Fact]
    public void AddOperator_OutOfBounds_EpochOutOfBoundsException()
    {
        Time difference = new(double.MaxValue);

        var exception = Record.Exception(() => Datasets.SimpleDateTimeEpoch + difference);

        Assert.IsType<EpochOutOfBoundsException>(exception);
    }

    [Fact]
    public void SubtractOperator_OutOfBounds_EpochOutOfBoundsException()
    {
        Time difference = new(double.MaxValue);

        var exception = Record.Exception(() => Datasets.SimpleDateTimeEpoch - difference);

        Assert.IsType<EpochOutOfBoundsException>(exception);
    }

    [Theory]
    [MemberData(nameof(ValidTimes))]
    public void AddMethod_ApproximateMatch(Time difference)
    {
        var julianDay = new JulianDay(2400000);
        var dateTimeEpoch = DateTimeEpoch.FromJulianDay(julianDay);

        var expected = dateTimeEpoch.ToJulianDay().Day + difference.Days;

        var actual = dateTimeEpoch.Add(difference);

        Assert.Equal(expected, actual.ToJulianDay().Day, Precision);
    }

    [Theory]
    [MemberData(nameof(ValidTimes))]
    public void AddOperator_ApproximateMatch(Time difference)
    {
        var julianDay = new JulianDay(2400000);
        var dateTimeEpoch = DateTimeEpoch.FromJulianDay(julianDay);

        var expected = dateTimeEpoch.ToJulianDay().Day + difference.Days;

        var actual = dateTimeEpoch + difference;

        Assert.Equal(expected, actual.ToJulianDay().Day, Precision);
    }

    [Theory]
    [MemberData(nameof(ValidTimes))]
    public void SubtractOperator_ApproximateMatch(Time difference)
    {
        var julianDay = new JulianDay(2400000);
        var dateTimeEpoch = DateTimeEpoch.FromJulianDay(julianDay);

        var expected = dateTimeEpoch.ToJulianDay().Day - difference.Days;

        var actual = dateTimeEpoch - difference;

        Assert.Equal(expected, actual.ToJulianDay().Day, Precision);
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
