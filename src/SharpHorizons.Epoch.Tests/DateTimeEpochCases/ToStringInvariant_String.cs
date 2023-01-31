namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System.Globalization;

using Xunit;

public class ToStringInvariant_String
{
    private static string Target(DateTimeEpoch epoch, string? format) => epoch.ToStringInvariant(format);

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void General_MatchDateTimeOffsetToStringWithCurrentCulture(DateTimeEpoch epoch)
    {
        var format = "G";

        MatchDateTimeOffsetToStringWithInvariantCulture(epoch, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void CustomFormat_MatchDateTimeOffsetToStringWithCurrentCulture(DateTimeEpoch epoch)
    {
        var format = "yyyy:MM:dd HH:mm:ss";

        MatchDateTimeOffsetToStringWithInvariantCulture(epoch, format);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Null_MatchDateTimeOffsetToStringWithCurrentCulture(DateTimeEpoch epoch)
    {
        string? format = null;

        MatchDateTimeOffsetToStringWithInvariantCulture(epoch, format);
    }

    private static void MatchDateTimeOffsetToStringWithInvariantCulture(DateTimeEpoch epoch, string? format)
    {
        var expected = epoch.DateTimeOffset.ToString(format, CultureInfo.InvariantCulture);

        var actual = Target(epoch, format);

        Assert.Equal(expected, actual);
    }
}
