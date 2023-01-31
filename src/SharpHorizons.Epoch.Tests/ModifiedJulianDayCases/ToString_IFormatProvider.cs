namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;
using System.Globalization;

using Xunit;

public class ToString_IFormatProvider
{
    private static string Target(ModifiedJulianDay modifiedJulianDay, IFormatProvider? provider) => modifiedJulianDay.ToString(provider);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Valid_MatchDoubleToString(ModifiedJulianDay modifiedJulianDay)
    {
        var provider = CultureInfo.CurrentCulture;

        MatchDoubleToString(modifiedJulianDay, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Null_MatchDoubleToString(ModifiedJulianDay modifiedJulianDay)
    {
        IFormatProvider? provider = null;

        MatchDoubleToString(modifiedJulianDay, provider);
    }

    private static void MatchDoubleToString(ModifiedJulianDay modifiedJulianDay, IFormatProvider? provider)
    {
        var expected = modifiedJulianDay.Day.ToString(provider);

        var actual = Target(modifiedJulianDay, provider);

        Assert.Equal(expected, actual);
    }
}
