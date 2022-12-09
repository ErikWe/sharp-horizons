namespace SharpHorizons.Tests.Epoch;

using System;
using System.Collections.Generic;

using Xunit;

public class EpochConstruction
{
    [Theory]
    [MemberData(nameof(NaN))]
    public void JulianDayNaN(double julianDayNumber)
    {
        Assert.Throws<ArgumentException>(() => new JulianDay(julianDayNumber));
    }

    [Theory]
    [MemberData(nameof(OutOfRange))]
    public void JulianDayOutOfRange(double julianDayNumber)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new JulianDay(julianDayNumber));
    }

    [Theory]
    [MemberData(nameof(NaN))]
    public void JulianDayFractionNaN(double fractionalDay)
    {
        Assert.Throws<ArgumentException>(() => new JulianDay(3, (float)fractionalDay));
    }

    [Theory]
    [MemberData(nameof(OutOfRangeFractionals))]
    public void JulianDayFractionOutOfRange(float fractionalDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new JulianDay(3, fractionalDay));
    }

    [Theory]
    [MemberData(nameof(NaN))]
    public void ModifiedJulianDayNaN(double modifiedJulianDayNumber)
    {
        Assert.Throws<ArgumentException>(() => new ModifiedJulianDay(modifiedJulianDayNumber));
    }

    [Theory]
    [MemberData(nameof(OutOfRange))]
    [InlineData(new object[] { int.MaxValue - 2400000 })]
    public void ModifiedJulianDayOutOfRange(double modifiedJulianDayNumber)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ModifiedJulianDay(modifiedJulianDayNumber));
    }

    [Theory]
    [MemberData(nameof(NaN))]
    public void ModifiedJulianDayFractionNaN(double fractionalDay)
    {
        Assert.Throws<ArgumentException>(() => new ModifiedJulianDay(3, (float)fractionalDay));
    }

    [Theory]
    [MemberData(nameof(OutOfRangeFractionals))]
    public void ModifiedJulianDayFractionOutOfRange(float fractionalDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ModifiedJulianDay(3, fractionalDay));
    }

    public static IEnumerable<object[]> NaN() => new object[][]
    {
        new object[] { double.NaN }
    };

    public static IEnumerable<object[]> OutOfRange() => new object[][]
    {
        new object[] { double.PositiveInfinity },
        new object[] { double.NegativeInfinity },
        new object[] { int.MaxValue + (long)1 },
        new object[] { int.MinValue - (long)1 }
    };

    public static IEnumerable<object[]> OutOfRangeFractionals() => new object[][]
    {
        new object[] { double.PositiveInfinity },
        new object[] { double.NegativeInfinity },
        new object[] { -0.007 },
        new object[] { 1.007 },
    };
}
