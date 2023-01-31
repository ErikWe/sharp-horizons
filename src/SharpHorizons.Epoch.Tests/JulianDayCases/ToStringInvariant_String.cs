namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System.Globalization;

using Xunit;

public class ToStringInvariant_String
{
    private static string Target(JulianDay julianDay, string? format) => julianDay.ToStringInvariant(format);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void General_MatchDoubleToStringWithInvariantCulture(JulianDay julianDay)
    {
        var format = "G";

        MatchDoubleToStringWithInvariantCulture(julianDay, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Currency_MatchInt32ToStringWithInvariantCulture(JulianDay majorObjectID)
    {
        var format = "C";

        MatchDoubleToStringWithInvariantCulture(majorObjectID, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Null_MatchInt32ToStringWithInvariantCulture(JulianDay majorObjectID)
    {
        string? format = null;

        MatchDoubleToStringWithInvariantCulture(majorObjectID, format);
    }

    private static void MatchDoubleToStringWithInvariantCulture(JulianDay julianDay, string? format)
    {
        var expected = julianDay.Day.ToString(format, CultureInfo.InvariantCulture);

        var actual = Target(julianDay, format);

        Assert.Equal(expected, actual);
    }
}
