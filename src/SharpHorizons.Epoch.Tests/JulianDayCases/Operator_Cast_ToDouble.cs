namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class Operator_Cast_ToDouble
{
    private static double Target(JulianDay julianDay) => (double)julianDay;

    [Fact]
    public void Null_ArgumentNullException()
    {
        var julianDay = Datasets.GetNullJulianDay();

        var exception = Record.Exception(() => Target(julianDay));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Valid_ExactMatch(JulianDay julianDay)
    {
        var actual = Target(julianDay);

        Assert.Equal(julianDay.Day, actual);
    }
}
