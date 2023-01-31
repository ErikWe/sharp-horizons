namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System;
using System.Globalization;

using Xunit;

public class ToString_IFormatProvider
{
    private static string Target(Epoch epoch, IFormatProvider? provider) => epoch.ToString(provider);

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Valid_MatchInstantToString(Epoch epoch)
    {
        var provider = CultureInfo.CurrentCulture;

        MatchInstantToString(epoch, provider);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Null_MatchInstantToString(Epoch epoch)
    {
        IFormatProvider? provider = null;

        MatchInstantToString(epoch, provider);
    }

    private static void MatchInstantToString(Epoch epoch, IFormatProvider? provider)
    {
        var expected = epoch.Instant.ToString(null, provider);

        var actual = Target(epoch, provider);

        Assert.Equal(expected, actual);
    }
}
