namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;
using System.Collections.Generic;

using Xunit;

public class EpochMaths
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(ValidModifiedJulianDays))]
    public void Method_ApproximateMatch(ModifiedJulianDay initialModifiedJulianDay, ModifiedJulianDay finalModifiedJulianDay)
    {
        var actual = finalModifiedJulianDay.Difference(initialModifiedJulianDay);

        Assert.Equal(finalModifiedJulianDay.Day - initialModifiedJulianDay.Day, actual.Days, Precision);
    }

    [Fact]
    public void Method_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ModifiedJulianDay.Epoch.Difference(null!));
    }

    [Theory]
    [MemberData(nameof(InvalidModifiedJulianDays))]
    public void Method_OutOfRange_ArgumentException(ModifiedJulianDay initialModifiedJulianDay, ModifiedJulianDay finalModifiedJulianDay)
    {
        Assert.Throws<ArgumentException>(() => finalModifiedJulianDay.Difference(initialModifiedJulianDay));
    }

    [Theory]
    [MemberData(nameof(ValidModifiedJulianDays))]
    public void Operator_ApproximateMatch(ModifiedJulianDay initialModifiedJulianDay, ModifiedJulianDay finalModifiedJulianDay)
    {
        var actual = finalModifiedJulianDay - initialModifiedJulianDay;

        Assert.Equal(finalModifiedJulianDay.Day - initialModifiedJulianDay.Day, actual.Days, Precision);
    }

    [Fact]
    public void Operator_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ModifiedJulianDay.Epoch - null!);
    }

    public static IEnumerable<object[]> ValidModifiedJulianDays() => new object[][]
    {
        new object[] { new ModifiedJulianDay(0), new ModifiedJulianDay(0) },
        new object[] { new ModifiedJulianDay(1), new ModifiedJulianDay(-1) },
        new object[] { new ModifiedJulianDay(-1), new ModifiedJulianDay(1) },
        new object[] { new ModifiedJulianDay(0), new ModifiedJulianDay(int.MinValue) },
        new object[] { new ModifiedJulianDay(0), new ModifiedJulianDay(int.MaxValue) },
        new object[] { new ModifiedJulianDay(int.MinValue), new ModifiedJulianDay(int.MinValue) },
        new object[] { new ModifiedJulianDay(int.MinValue), new ModifiedJulianDay(int.MaxValue) },
        new object[] { new ModifiedJulianDay(int.MinValue), new ModifiedJulianDay(0) }
    };

    public static IEnumerable<object[]> InvalidModifiedJulianDays() => new object[][]
    {
        new object[] { new ModifiedJulianDay(int.MaxValue), new ModifiedJulianDay(0) }
    };
}
