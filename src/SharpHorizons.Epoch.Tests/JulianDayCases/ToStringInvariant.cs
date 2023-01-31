namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System.Globalization;

using Xunit;

public class ToStringInvariant
{
    private static string Target(JulianDay julianDay) => julianDay.ToStringInvariant();

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Valid_MatchDoubleToStringWithInvariantCulture(JulianDay julianDay)
    {
        var expected = julianDay.Day.ToString(CultureInfo.InvariantCulture);

        var actual = Target(julianDay);

        Assert.Equal(expected, actual);
    }
}
