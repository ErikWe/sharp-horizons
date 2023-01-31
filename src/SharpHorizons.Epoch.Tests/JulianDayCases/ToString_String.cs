namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString_String
{
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString(string).")]
    private static string Target(JulianDay julianDay, string? format) => julianDay.ToString(format);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void General_MatchDoubleToStringWithCurrentCulture(JulianDay julianDay)
    {
        var format = "G";

        MatchDoubleToStringWithCurrentCulture(julianDay, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void FloatingPoint_MatchDoubleToStringWithCurrentCulture(JulianDay julianDay)
    {
        var format = "F4";

        MatchDoubleToStringWithCurrentCulture(julianDay, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Null_MatchDoubleToStringWithCurrentCulture(JulianDay julianDay)
    {
        string? format = null;

        MatchDoubleToStringWithCurrentCulture(julianDay, format);
    }

    private static void MatchDoubleToStringWithCurrentCulture(JulianDay julianDay, string? format)
    {
        var expected = julianDay.Day.ToString(format, CultureInfo.CurrentCulture);

        var actual = Target(julianDay, format);

        Assert.Equal(expected, actual);
    }
}
