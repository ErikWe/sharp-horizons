namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

internal static class Asserter
{
    private static int Precision => 5;

    public static void Approximate(double expectedModifiedJulianDayNumber, double actualJModifiedulianDayNumber) => Assert.Equal(expectedModifiedJulianDayNumber, actualJModifiedulianDayNumber, Precision);

    public static void Exact(int expectedIntegralDay, float expectedFractionalDay, int actualIntegralDay, float actualFractionalDay)
    {
        Assert.Equal(expectedIntegralDay, actualIntegralDay);
        Assert.Equal(expectedFractionalDay, actualFractionalDay);
    }

    public static void Approximate(int expectedIntegralDay, float expectedFractionalDay, int actualIntegralDay, float actualFractionalDay)
    {
        Assert.Equal(expectedIntegralDay, actualIntegralDay);
        Assert.Equal(expectedFractionalDay, actualFractionalDay, Precision);
    }
}
