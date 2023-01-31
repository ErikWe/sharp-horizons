namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System;
using System.Globalization;

using Xunit;

public class ToString_StringIFormatProvider
{
    private static string Target(Epoch epoch, string? format, IFormatProvider? provider) => epoch.ToString(format, provider);

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void General_MatchInstantToString(Epoch epoch)
    {
        var format = "g";
        var provider = CultureInfo.CurrentCulture;

        MatchInstantToString(epoch, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void CustomFormat_MatchInstantToString(Epoch epoch)
    {
        var format = "yyyy:MM:dd HH:mm:ss";
        var provider = CultureInfo.CurrentCulture;

        MatchInstantToString(epoch, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void NullString_MatcInstantToString(Epoch epoch)
    {
        string? format = null;
        var provider = CultureInfo.CurrentCulture;

        MatchInstantToString(epoch, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void NullIFormatProvider_MatchInstantToString(Epoch epoch)
    {
        var format = "g";
        IFormatProvider? provider = null;

        MatchInstantToString(epoch, format, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void NullStringAndIFormatProvider_MatchInstantToString(Epoch epoch)
    {
        string? format = null;
        IFormatProvider? provider = null;

        MatchInstantToString(epoch, format, provider);
    }

    private static void MatchInstantToString(Epoch epoch, string? format, IFormatProvider? provider)
    {
        var expected = epoch.Instant.ToString(format, provider);

        var actual = Target(epoch, format, provider);

        Assert.Equal(expected, actual);
    }
}
