namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString
{
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString().")]
    private static string Target(ModifiedJulianDay modifiedJulianDay) => modifiedJulianDay.ToString();

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Valid_MatchDoubleToStringWithCurrentCulture(ModifiedJulianDay modifiedJulianDay)
    {
        var expected = modifiedJulianDay.Day.ToString(CultureInfo.CurrentCulture);

        var actual = Target(modifiedJulianDay);

        Assert.Equal(expected, actual);
    }
}
