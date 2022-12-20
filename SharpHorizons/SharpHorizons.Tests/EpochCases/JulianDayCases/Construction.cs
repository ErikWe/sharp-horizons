namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;
using System.Collections.Generic;

using Xunit;

public class Construction
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(Combined_Valid))]
    public void Combined_Valid_ApproximateMatch(double julianDayNumber)
    {
        JulianDay julianDay = new(julianDayNumber);

        Assert.Equal(julianDayNumber, julianDay.Day, Precision);
    }

    [Theory]
    [MemberData(nameof(Partwise_Valid))]
    public void Partwise_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        JulianDay julianDay = new(integralDay, fractionalDay);

        Assert.Equal(integralDay, julianDay.IntegralDay);
        Assert.Equal(fractionalDay, julianDay.FractionalDay);
    }

    [Fact]
    public void Combined_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new JulianDay(double.NaN));
    }

    [Fact]
    public void Partwise_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new JulianDay(0, float.NaN));
    }

    [Theory]
    [MemberData(nameof(Combined_OutOfRange))]
    public void Combined_OutOfRange_ArgumentOutOfRangeException(double julianDayNumber)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new JulianDay(julianDayNumber));
    }

    [Theory]
    [MemberData(nameof(Partwise_OutOfRange))]
    public void Partwise_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new JulianDay(integralDay, fractionalDay));
    }

    [Theory]
    [MemberData(nameof(Partwise_Valid))]
    public void Initialization_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        JulianDay julianDay = new() { IntegralDay = integralDay, FractionalDay = fractionalDay };

        Assert.Equal(integralDay, julianDay.IntegralDay);
        Assert.Equal(fractionalDay, julianDay.FractionalDay);
    }

    [Fact]
    public void Initialization_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new JulianDay() { IntegralDay = 0, FractionalDay = float.NaN });
    }

    [Theory]
    [MemberData(nameof(Partwise_OutOfRange))]
    public void Initialization_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new JulianDay() { IntegralDay = integralDay, FractionalDay = fractionalDay });
    }

    [Theory]
    [MemberData(nameof(Combined_Valid))]
    public void CastFromDouble_Valid_ApproximateMatch(double julianDayNumber)
    {
        var julianDay = (JulianDay)julianDayNumber;

        Assert.Equal(julianDayNumber, julianDay.Day, Precision);
    }

    [Fact]
    public void CastFromDouble_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => (JulianDay)double.NaN);
    }

    [Theory]
    [MemberData(nameof(Combined_OutOfRange))]
    public void CastFromDouble_OutOfRange_ArgumentOutOfRangeException(double julianDayNumber)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => (JulianDay)julianDayNumber);
    }

    public static IEnumerable<object[]> Combined_Valid() => new object[][]
    {
        new object[] { int.MaxValue + 0.99 },
        new object[] { (double)int.MinValue },
        new object[] { 0 },
        new object[] { -10.14 },
        new object[] { 10.14 }
    };

    public static IEnumerable<object[]> Combined_OutOfRange() => new object[][]
    {
        new object[] { double.PositiveInfinity },
        new object[] { double.NegativeInfinity },
        new object[] { int.MaxValue + 1.01 },
        new object[] { int.MinValue - 0.01 }
    };

    public static IEnumerable<object[]> Partwise_Valid() => new object[][]
    {
        new object[] { int.MaxValue, 0.99f },
        new object[] { int.MaxValue, 0.01f },
        new object[] { int.MinValue, 0.99f },
        new object[] { int.MinValue, 0.01f },
        new object[] { 0, 0 },
        new object[] { -10, float.Epsilon },
        new object[] { 10, 0.42 }
    };

    public static IEnumerable<object[]> Partwise_OutOfRange() => new object[][]
    {
        new object[] { 0, float.PositiveInfinity },
        new object[] { 0, float.NegativeInfinity },
        new object[] { 0, -0.007f },
        new object[] { 0, 1.007f },
    };
}
