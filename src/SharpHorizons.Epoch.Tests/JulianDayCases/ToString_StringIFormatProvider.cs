namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;
using System.Globalization;

using Xunit;

public class ToString_StringIFormatProvider
{
    private static string Target(JulianDay julianDay, string? format, IFormatProvider? provider) => julianDay.ToString(format, provider);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void General_MatchDoubleToString(JulianDay julianDay)
    {
        var format = "G";
        var provider = CultureInfo.CurrentCulture;

        MatchDoubleToString(julianDay, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void FloatingPoint_MatchDoubleToString(JulianDay julianDay)
    {
        var format = "F4";
        var provider = CultureInfo.CurrentCulture;

        MatchDoubleToString(julianDay, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void NullString_MatchDoubleToString(JulianDay julianDay)
    {
        string? format = null;
        var provider = CultureInfo.CurrentCulture;

        MatchDoubleToString(julianDay, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void NullIFormatProvider_MatchDoubleToString(JulianDay julianDay)
    {
        var format = "G";
        IFormatProvider? provider = null;

        MatchDoubleToString(julianDay, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void NullStringAndIFormatProvider_MatchDoubleToString(JulianDay julianDay)
    {
        string? format = null;
        IFormatProvider? provider = null;

        MatchDoubleToString(julianDay, format, provider);
    }

    private static void MatchDoubleToString(JulianDay julianDay, string? format, IFormatProvider? provider)
    {
        var expected = julianDay.Day.ToString(format, provider);

        var actual = Target(julianDay, format, provider);

        Assert.Equal(expected, actual);
    }
}
