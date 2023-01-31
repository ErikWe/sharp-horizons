namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;
using System.Globalization;

using Xunit;

public class ToString_IFormatProvider
{
    private static string Target(JulianDay julianDay, IFormatProvider? provider) => julianDay.ToString(provider);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Valid_MatchDoubleToString(JulianDay julianDay)
    {
        var provider = CultureInfo.CurrentCulture;

        MatchDoubleToString(julianDay, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Null_MatchDoubleToString(JulianDay julianDay)
    {
        IFormatProvider? provider = null;

        MatchDoubleToString(julianDay, provider);
    }

    private static void MatchDoubleToString(JulianDay julianDay, IFormatProvider? provider)
    {
        var expected = julianDay.Day.ToString(provider);

        var actual = Target(julianDay, provider);

        Assert.Equal(expected, actual);
    }
}
