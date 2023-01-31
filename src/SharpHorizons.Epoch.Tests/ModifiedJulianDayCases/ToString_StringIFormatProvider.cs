namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;
using System.Globalization;

using Xunit;

public class ToString_StringIFormatProvider
{
    private static string Target(ModifiedJulianDay modifiedJulianDay, string? format, IFormatProvider? provider) => modifiedJulianDay.ToString(format, provider);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void General_MatchDoubleToString(ModifiedJulianDay modifiedJulianDay)
    {
        var format = "G";
        var provider = CultureInfo.CurrentCulture;

        MatchDoubleToString(modifiedJulianDay, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void FloatingPoint_MatchDoubleToString(ModifiedJulianDay modifiedJulianDay)
    {
        var format = "F4";
        var provider = CultureInfo.CurrentCulture;

        MatchDoubleToString(modifiedJulianDay, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void NullString_MatchDoubleToString(ModifiedJulianDay modifiedJulianDay)
    {
        string? format = null;
        var provider = CultureInfo.CurrentCulture;

        MatchDoubleToString(modifiedJulianDay, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void NullIFormatProvider_MatchDoubleToString(ModifiedJulianDay modifiedJulianDay)
    {
        var format = "G";
        IFormatProvider? provider = null;

        MatchDoubleToString(modifiedJulianDay, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void NullStringAndIFormatProvider_MatchDoubleToString(ModifiedJulianDay modifiedJulianDay)
    {
        string? format = null;
        IFormatProvider? provider = null;

        MatchDoubleToString(modifiedJulianDay, format, provider);
    }

    private static void MatchDoubleToString(ModifiedJulianDay modifiedJulianDay, string? format, IFormatProvider? provider)
    {
        var expected = modifiedJulianDay.Day.ToString(format, provider);

        var actual = Target(modifiedJulianDay, format, provider);

        Assert.Equal(expected, actual);
    }
}
