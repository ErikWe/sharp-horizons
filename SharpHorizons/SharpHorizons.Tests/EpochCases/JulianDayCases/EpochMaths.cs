namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

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

    [Theory]
    [MemberData(nameof(JulianDays))]
    public void JulianDayOperator_ApproximateMatch(JulianDay initialJulianDay, JulianDay finalJulianDay)
    {
        var actual = finalJulianDay - initialJulianDay;

        Assert.Equal(finalJulianDay.Day - initialJulianDay.Day, actual.Days, Precision);
    }

    [Theory]
    [MemberData(nameof(JulianDays))]
    public void IEpochMethod_ApproximateMatch(IEpoch initialEpoch, JulianDay finalJulianDay)
    {
        var actual = finalJulianDay.Difference(initialEpoch);

        Assert.Equal(finalJulianDay.Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Theory]
    [MemberData(nameof(JulianDays))]
    public void IEpochOperator_ApproximateMatch(IEpoch initialEpoch, JulianDay finalJulianDay)
    {
        var actual = finalJulianDay - initialEpoch;

        Assert.Equal(finalJulianDay.Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    public static IEnumerable<object[]> JulianDays() => new object[][]
    {
        new object[] { new JulianDay(0), new JulianDay(0) },
        new object[] { new JulianDay(1), new JulianDay(-1) },
        new object[] { new JulianDay(-1), new JulianDay(1) }
    };
}
