namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class ToDouble
{
    private static double Target(ModifiedJulianDay modifiedJulianDay) => modifiedJulianDay.ToDouble();

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Valid_ExactMatch(ModifiedJulianDay modifiedJulianDay)
    {
        var actual = Target(modifiedJulianDay);

        Assert.Equal(modifiedJulianDay.Day, actual);
    }
}
