namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;
using System.Collections.Generic;

using Xunit;

public class WithJulianDay
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(Conversions))]
    public void From_Valid_ApproximatelyOffsetByConstant(JulianDay julianDay, ModifiedJulianDay expected)
    {
        var actual = ModifiedJulianDay.FromJulianDay(julianDay);

        Assert.Equal(expected.Day, actual.Day, Precision);
    }

    [Theory]
    [MemberData(nameof(UnconvertibleJulianDays))]
    public void From_OutOfRange_ArgumentOutOfRangeException(JulianDay julianDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => ModifiedJulianDay.FromJulianDay(julianDay));
    }

    [Fact]
    public void From_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ModifiedJulianDay.FromJulianDay(null!));
    }

    [Theory]
    [MemberData(nameof(Conversions))]
    public void To_ApproximatelyOffsetByConstant(JulianDay expected, ModifiedJulianDay modifiedJulianDay)
    {
        var actual = modifiedJulianDay.ToJulianDay();

        Assert.Equal(expected.Day, actual.Day, Precision);
    }

    [Theory]
    [MemberData(nameof(UnconvertibleModifiedJulianDays))]
    public void To_OutOfRange_EpochOutOfBoundsException(ModifiedJulianDay modifiedJulianDay)
    {
        Assert.Throws<EpochOutOfBoundsException>(modifiedJulianDay.ToJulianDay);
    }

    public static IEnumerable<object[]> Conversions() => new object[][]
    {
        new object[] { JulianDay.Epoch, new ModifiedJulianDay(-2400000.5) },
        new object[] { new JulianDay(2400000.5), ModifiedJulianDay.Epoch },
        new object[] { new JulianDay(int.MaxValue + 0.49), new ModifiedJulianDay(int.MaxValue - 2400000.01) },
        new object[] { new JulianDay(int.MinValue + 2400000.5), new ModifiedJulianDay(int.MinValue) }
    };

    public static IEnumerable<object[]> UnconvertibleJulianDays() => new object[][]
    {
        new object[] { new JulianDay(int.MinValue) }
    };

    public static IEnumerable<object[]> UnconvertibleModifiedJulianDays() => new object[][]
    {
        new object[] { new ModifiedJulianDay(int.MaxValue) }
    };
}
