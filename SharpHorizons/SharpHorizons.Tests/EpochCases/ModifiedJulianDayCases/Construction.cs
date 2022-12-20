namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;
using System.Collections.Generic;

using Xunit;

public class Construction
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(Combined_Valid))]
    public void Combined_Valid_ApproximateMatch(double modifiedJulianDayNumber)
    {
        ModifiedJulianDay modifiedJulianDay = new(modifiedJulianDayNumber);

        Assert.Equal(modifiedJulianDayNumber, modifiedJulianDay.Day, Precision);
    }

    [Theory]
    [MemberData(nameof(Partwise_Valid))]
    public void Partwise_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        ModifiedJulianDay modifiedJulianDay = new(integralDay, fractionalDay);

        Assert.Equal(integralDay, modifiedJulianDay.IntegralDay);
        Assert.Equal(fractionalDay, modifiedJulianDay.FractionalDay);
    }

    [Fact]
    public void Combined_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new ModifiedJulianDay(double.NaN));
    }

    [Fact]
    public void Partwise_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new ModifiedJulianDay(0, float.NaN));
    }

    [Theory]
    [MemberData(nameof(Combined_OutOfRange))]
    public void Combined_OutOfRange_ArgumentOutOfRangeException(double modifiedJulianDayNumber)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ModifiedJulianDay(modifiedJulianDayNumber));
    }

    [Theory]
    [MemberData(nameof(Partwise_OutOfRange))]
    public void Partwise_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ModifiedJulianDay(integralDay, fractionalDay));
    }

    [Theory]
    [MemberData(nameof(Partwise_Valid))]
    public void Initialization_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        ModifiedJulianDay modifiedJulianDay = new() { IntegralDay = integralDay, FractionalDay = fractionalDay };

        Assert.Equal(integralDay, modifiedJulianDay.IntegralDay);
        Assert.Equal(fractionalDay, modifiedJulianDay.FractionalDay);
    }

    [Fact]
    public void Initialization_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new ModifiedJulianDay() { IntegralDay = 0, FractionalDay = float.NaN });
    }

    [Theory]
    [MemberData(nameof(Partwise_OutOfRange))]
    public void Initialization_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ModifiedJulianDay() { IntegralDay = integralDay, FractionalDay = fractionalDay });
    }

    [Theory]
    [MemberData(nameof(Combined_Valid))]
    public void CastFromDouble_Valid_ApproximateMatch(double modifiedJulianDayNumber)
    {
        var modifiedJulianDay = (ModifiedJulianDay)modifiedJulianDayNumber;

        Assert.Equal(modifiedJulianDayNumber, modifiedJulianDay.Day, Precision);
    }

    [Fact]
    public void CastFromDouble_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => (ModifiedJulianDay)double.NaN);
    }

    [Theory]
    [MemberData(nameof(Combined_OutOfRange))]
    public void CastFromDouble_OutOfRange_ArgumentOutOfRangeException(double modifiedJulianDayNumber)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => (ModifiedJulianDay)modifiedJulianDayNumber);
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
