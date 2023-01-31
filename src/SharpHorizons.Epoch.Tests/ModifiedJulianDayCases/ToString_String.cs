namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString_String
{
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString(string).")]
    private static string Target(ModifiedJulianDay modifiedJulianDay, string? format) => modifiedJulianDay.ToString(format);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void General_MatchDoubleToStringWithCurrentCulture(ModifiedJulianDay modifiedJulianDay)
    {
        var format = "G";

        MatchDoubleToStringWithCurrentCulture(modifiedJulianDay, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void FloatingPoint_MatchDoubleToStringWithCurrentCulture(ModifiedJulianDay modifiedJulianDay)
    {
        var format = "F4";

        MatchDoubleToStringWithCurrentCulture(modifiedJulianDay, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Null_MatchDoubleToStringWithCurrentCulture(ModifiedJulianDay modifiedJulianDay)
    {
        string? format = null;

        MatchDoubleToStringWithCurrentCulture(modifiedJulianDay, format);
    }

    private static void MatchDoubleToStringWithCurrentCulture(ModifiedJulianDay modifiedJulianDay, string? format)
    {
        var expected = modifiedJulianDay.Day.ToString(format, CultureInfo.CurrentCulture);

        var actual = Target(modifiedJulianDay, format);

        Assert.Equal(expected, actual);
    }
}
