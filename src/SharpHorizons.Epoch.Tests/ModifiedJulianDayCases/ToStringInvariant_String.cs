namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System.Globalization;

using Xunit;

public class ToStringInvariant_String
{
    private static string Target(ModifiedJulianDay modifiedJulianDay, string? format) => modifiedJulianDay.ToStringInvariant(format);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void General_MatchDoubleToStringWithCurrentCulture(ModifiedJulianDay modifiedJulianDay)
    {
        var format = "G";

        MatchDoubleToStringWithInvariantCulture(modifiedJulianDay, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void FloatingPoint_MatchDoubleToStringWithCurrentCulture(ModifiedJulianDay modifiedJulianDay)
    {
        var format = "F4";

        MatchDoubleToStringWithInvariantCulture(modifiedJulianDay, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Null_MatchDoubleToStringWithCurrentCulture(ModifiedJulianDay modifiedJulianDay)
    {
        string? format = null;

        MatchDoubleToStringWithInvariantCulture(modifiedJulianDay, format);
    }

    private static void MatchDoubleToStringWithInvariantCulture(ModifiedJulianDay modifiedJulianDay, string? format)
    {
        var expected = modifiedJulianDay.Day.ToString(format, CultureInfo.InvariantCulture);

        var actual = Target(modifiedJulianDay, format);

        Assert.Equal(expected, actual);
    }
}
