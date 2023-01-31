namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class ToDouble
{
    private static double Target(JulianDay julianDay) => julianDay.ToDouble();

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Valid_ExactMatch(JulianDay julianDay)
    {
        var actual = Target(julianDay);

        Assert.Equal(julianDay.Day, actual);
    }
}
