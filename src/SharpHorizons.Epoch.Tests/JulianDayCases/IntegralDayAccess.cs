namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class IntegralDayAccess
{
    private static int Target(JulianDay julianDay) => julianDay.IntegralDay;

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Valid_NoException(JulianDay julianDay)
    {
        var exception = Record.Exception(() => Target(julianDay));

        Assert.Null(exception);
    }
}
