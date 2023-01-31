namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class DayAccess
{
    private static double Target(ModifiedJulianDay modifiedJulianDay) => modifiedJulianDay.Day;

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Valid_ApproximatelyEqualToIntegralDayPlusFractionalDay(ModifiedJulianDay modifiedJulianDay)
    {
        var expected = modifiedJulianDay.IntegralDay + (double)modifiedJulianDay.FractionalDay;

        var actual = Target(modifiedJulianDay);

        Asserter.Approximate(expected, actual);
    }
}
