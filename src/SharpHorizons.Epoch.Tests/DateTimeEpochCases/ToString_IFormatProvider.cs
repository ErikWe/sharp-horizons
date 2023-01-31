namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Globalization;

using Xunit;

public class ToString_IFormatProvider
{
    private static string Target(DateTimeEpoch epoch, IFormatProvider? provider) => epoch.ToString(provider);

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Valid_MatchDateTimeOffsetToString(DateTimeEpoch epoch)
    {
        var provider = CultureInfo.CurrentCulture;

        MatchDateTimeOffsetToString(epoch, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Null_MatchDateTimeOffsetToString(DateTimeEpoch epoch)
    {
        IFormatProvider? provider = null;

        MatchDateTimeOffsetToString(epoch, provider);
    }

    private static void MatchDateTimeOffsetToString(DateTimeEpoch epoch, IFormatProvider? provider)
    {
        var expected = epoch.DateTimeOffset.ToString(provider);

        var actual = Target(epoch, provider);

        Assert.Equal(expected, actual);
    }
}
