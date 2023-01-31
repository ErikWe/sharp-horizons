namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class FractionalDayAccess
{
    private static float Target(JulianDay julianDay) => julianDay.FractionalDay;

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Valid_NoException(JulianDay julianDay)
    {
        var exception = Record.Exception(() => Target(julianDay));

        Assert.Null(exception);
    }
}
