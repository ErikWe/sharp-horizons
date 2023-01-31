namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Globalization;

using Xunit;

public class ToString_StringIFormatProvider
{
    private static string Target(DateTimeEpoch epoch, string? format, IFormatProvider? provider) => epoch.ToString(format, provider);

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void General_MatchDateTimeOffsetToString(DateTimeEpoch epoch)
    {
        var format = "G";
        var provider = CultureInfo.CurrentCulture;

        MatchDateTimeOffsetToString(epoch, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void CustomFormat_MatchDateTimeOffsetToString(DateTimeEpoch epoch)
    {
        var format = "yyyy:MM:dd HH:mm:ss";
        var provider = CultureInfo.CurrentCulture;

        MatchDateTimeOffsetToString(epoch, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void NullString_MatcDateTimeOffsetToString(DateTimeEpoch epoch)
    {
        string? format = null;
        var provider = CultureInfo.CurrentCulture;

        MatchDateTimeOffsetToString(epoch, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void NullIFormatProvider_MatchDateTimeOffsetToString(DateTimeEpoch epoch)
    {
        var format = "G";
        IFormatProvider? provider = null;

        MatchDateTimeOffsetToString(epoch, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void NullStringAndIFormatProvider_MatchDateTimeOffsetToString(DateTimeEpoch epoch)
    {
        string? format = null;
        IFormatProvider? provider = null;

        MatchDateTimeOffsetToString(epoch, format, provider);
    }

    private static void MatchDateTimeOffsetToString(DateTimeEpoch epoch, string? format, IFormatProvider? provider)
    {
        var expected = epoch.DateTimeOffset.ToString(format, provider);

        var actual = Target(epoch, format, provider);

        Assert.Equal(expected, actual);
    }
}
