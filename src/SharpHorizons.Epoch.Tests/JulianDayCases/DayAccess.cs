namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class DayAccess
{
    private static double Target(JulianDay julianDay) => julianDay.Day;

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Valid_ApproximatelyEqualToIntegralDayPlusFractionalDay(JulianDay julianDay)
    {
        var expected = julianDay.IntegralDay + (double)julianDay.FractionalDay;

        var actual = Target(julianDay);

        Asserter.Approximate(expected, actual);
    }
}
