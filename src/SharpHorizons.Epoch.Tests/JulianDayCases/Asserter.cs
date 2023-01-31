namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

internal static class Asserter
{
    private static int Precision => 6;

    public static void Approximate(double expectedJulianDayNumber, double actualJulianDayNumber) => Assert.Equal(expectedJulianDayNumber, actualJulianDayNumber, Precision);
}
