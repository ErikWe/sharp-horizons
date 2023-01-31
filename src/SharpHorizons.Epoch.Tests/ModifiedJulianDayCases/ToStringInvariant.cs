namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System.Globalization;

using Xunit;

public class ToStringInvariant
{
    private static string Target(ModifiedJulianDay modifiedJulianDay) => modifiedJulianDay.ToStringInvariant();

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Valid_MatchDoubleToStringWithInvariantCulture(ModifiedJulianDay modifiedJulianDay)
    {
        var expected = modifiedJulianDay.Day.ToString(CultureInfo.InvariantCulture);

        var actual = Target(modifiedJulianDay);

        Assert.Equal(expected, actual);
    }
}
