namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class FractionalDayAccess
{
    private static float Target(ModifiedJulianDay modifiedJulianDay) => modifiedJulianDay.FractionalDay;

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Valid_NoException(ModifiedJulianDay modifiedJulianDay)
    {
        var exception = Record.Exception(() => Target(modifiedJulianDay));

        Assert.Null(exception);
    }
}
