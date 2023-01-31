namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString
{
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString().")]
    private static string Target(JulianDay julianDay) => julianDay.ToString();

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Valid_MatchDoubleToStringWithCurrentCulture(JulianDay julianDay)
    {
        var expected = julianDay.Day.ToString(CultureInfo.CurrentCulture);

        var actual = Target(julianDay);

        Assert.Equal(expected, actual);
    }
}
