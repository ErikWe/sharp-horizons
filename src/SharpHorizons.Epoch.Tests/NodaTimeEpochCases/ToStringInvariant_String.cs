namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System.Globalization;

using Xunit;

public class ToStringInvariant_String
{
    private static string Target(Epoch epoch, string? format) => epoch.ToStringInvariant(format);

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void General_MatchInstantToStringWithCurrentCulture(Epoch epoch)
    {
        var format = "g";

        MatchInstantToStringWithInvariantCulture(epoch, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void CustomFormat_MatchInstantToStringWithCurrentCulture(Epoch epoch)
    {
        var format = "yyyy:MM:dd HH:mm:ss";

        MatchInstantToStringWithInvariantCulture(epoch, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Null_MatchInstantToStringWithCurrentCulture(Epoch epoch)
    {
        string? format = null;

        MatchInstantToStringWithInvariantCulture(epoch, format);
    }

    private static void MatchInstantToStringWithInvariantCulture(Epoch epoch, string? format)
    {
        var expected = epoch.Instant.ToString(format, CultureInfo.InvariantCulture);

        var actual = Target(epoch, format);

        Assert.Equal(expected, actual);
    }
}
