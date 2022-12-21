namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class EpochMaths
{
    private static int TimePrecision { get; } = 5;

    [Theory]
    [ClassData(typeof(Datasets.TwoJulianDays))]
    public void JulianDayMethod_ApproximateMatch(JulianDay initialJulianDay, JulianDay finalJulianDay)
    {
        var actual = finalJulianDay.Difference(initialJulianDay);

        Assert.Equal(finalJulianDay.Day - initialJulianDay.Day, actual.Days, TimePrecision);
    }

    [Fact]
    public void JulianDayMethod_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => JulianDay.Epoch.Difference(null!));
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoJulianDays))]
    public void JulianDayOperator_ApproximateMatch(JulianDay initialJulianDay, JulianDay finalJulianDay)
    {
        var actual = finalJulianDay - initialJulianDay;

        Assert.Equal(finalJulianDay.Day - initialJulianDay.Day, actual.Days, TimePrecision);
    }

    [Fact]
    public void JulianDayOperator_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => JulianDay.Epoch - null!);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoJulianDays))]
    public void IEpochMethod_ApproximateMatch(IEpoch initialEpoch, JulianDay finalJulianDay)
    {
        var actual = finalJulianDay.Difference(initialEpoch);

        Assert.Equal(finalJulianDay.Day - initialEpoch.ToJulianDay().Day, actual.Days, TimePrecision);
    }

    [Fact]
    public void IEpochMethod_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => JulianDay.Epoch.Difference((IEpoch)null!));
    }
}
