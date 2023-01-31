namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString_String
{
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString(string).")]
    private static string Target(DateTimeEpoch epoch, string? format) => epoch.ToString(format);

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void General_MatchDateTimeOffsetToStringWithCurrentCulture(DateTimeEpoch epoch)
    {
        var format = "G";

        MatchDateTimeOffsetToStringWithCurrentCulture(epoch, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void CustomFormat_MatchDateTimeOffsetToStringWithCurrentCulture(DateTimeEpoch epoch)
    {
        var format = "yyyy:MM:dd HH:mm:ss";

        MatchDateTimeOffsetToStringWithCurrentCulture(epoch, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Null_MatchDateTimeOffsetToStringWithCurrentCulture(DateTimeEpoch epoch)
    {
        string? format = null;

        MatchDateTimeOffsetToStringWithCurrentCulture(epoch, format);
    }

    private static void MatchDateTimeOffsetToStringWithCurrentCulture(DateTimeEpoch epoch, string? format)
    {
        var expected = epoch.DateTimeOffset.ToString(format, CultureInfo.CurrentCulture);

        var actual = Target(epoch, format);

        Assert.Equal(expected, actual);
    }
}
