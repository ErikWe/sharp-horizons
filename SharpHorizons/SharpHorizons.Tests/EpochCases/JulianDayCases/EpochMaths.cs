namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;
using System.Collections.Generic;

using Xunit;

public class EpochMaths
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(JulianDays))]
    public void JulianDayMethod_ApproximateMatch(JulianDay initialJulianDay, JulianDay finalJulianDay)
    {
        var actual = finalJulianDay.Difference(initialJulianDay);

        Assert.Equal(finalJulianDay.Day - initialJulianDay.Day, actual.Days, Precision);
    }

    [Fact]
    public void JulianDayMethod_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => JulianDay.Epoch.Difference(null!));
    }

    [Theory]
    [MemberData(nameof(JulianDays))]
    public void JulianDayOperator_ApproximateMatch(JulianDay initialJulianDay, JulianDay finalJulianDay)
    {
        var actual = finalJulianDay - initialJulianDay;

        Assert.Equal(finalJulianDay.Day - initialJulianDay.Day, actual.Days, Precision);
    }

    [Fact]
    public void JulianDayOperator_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => JulianDay.Epoch - null!);
    }

    [Theory]
    [MemberData(nameof(JulianDays))]
    public void IEpochMethod_ApproximateMatch(IEpoch initialEpoch, JulianDay finalJulianDay)
    {
        var actual = finalJulianDay.Difference(initialEpoch);

        Assert.Equal(finalJulianDay.Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Fact]
    public void IEpochMethod_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => JulianDay.Epoch.Difference((IEpoch)null!));
    }

    public static IEnumerable<object[]> JulianDays() => new object[][]
    {
        new object[] { new JulianDay(0), new JulianDay(0) },
        new object[] { new JulianDay(1), new JulianDay(-1) },
        new object[] { new JulianDay(-1), new JulianDay(1) },
        new object[] { new JulianDay(0), new JulianDay(int.MinValue) },
        new object[] { new JulianDay(0), new JulianDay(int.MaxValue) },
        new object[] { new JulianDay(int.MaxValue), new JulianDay(0) },
        new object[] { new JulianDay(int.MaxValue), new JulianDay(int.MinValue) },
        new object[] { new JulianDay(int.MaxValue), new JulianDay(int.MaxValue) },
        new object[] { new JulianDay(int.MinValue), new JulianDay(int.MinValue) },
        new object[] { new JulianDay(int.MinValue), new JulianDay(int.MaxValue) },
        new object[] { new JulianDay(int.MinValue), new JulianDay(0) }
    };
}
