namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString_String
{
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString(string).")]
    private static string Target(Epoch epoch, string? format) => epoch.ToString(format);

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void General_MatchInstantToStringWithCurrentCulture(Epoch epoch)
    {
        var format = "g";

        MatchInstantToStringWithCurrentCulture(epoch, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void CustomFormat_MatchInstantToStringWithCurrentCulture(Epoch epoch)
    {
        var format = "yyyy:MM:dd HH:mm:ss";

        MatchInstantToStringWithCurrentCulture(epoch, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Null_MatchInstantToStringWithCurrentCulture(Epoch epoch)
    {
        string? format = null;

        MatchInstantToStringWithCurrentCulture(epoch, format);
    }

    private static void MatchInstantToStringWithCurrentCulture(Epoch epoch, string? format)
    {
        var expected = epoch.Instant.ToString(format, CultureInfo.CurrentCulture);

        var actual = Target(epoch, format);

        Assert.Equal(expected, actual);
    }
}
