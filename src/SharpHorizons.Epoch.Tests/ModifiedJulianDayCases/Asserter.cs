namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

internal static class Asserter
{
    private static int Precision => 6;

    public static void Approximate(double expectedModifiedJulianDayNumber, double actualJModifiedulianDayNumber) => Assert.Equal(expectedModifiedJulianDayNumber, actualJModifiedulianDayNumber, Precision);
}
