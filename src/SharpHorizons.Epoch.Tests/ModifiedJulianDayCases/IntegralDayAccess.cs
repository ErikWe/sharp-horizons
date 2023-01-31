namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class IntegralDayAccess
{
    private static double Target(ModifiedJulianDay modifiedJulianDay) => modifiedJulianDay.IntegralDay;

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Valid_NoException(ModifiedJulianDay modifiedJulianDay)
    {
        var exception = Record.Exception(() => Target(modifiedJulianDay));

        Assert.Null(exception);
    }
}
