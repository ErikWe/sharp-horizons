namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString
{
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString().")]
    private static string Target(DateTimeEpoch epoch) => epoch.ToString();

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Valid_MatchDateTimeOffsetToStringWithCurrentCulture(DateTimeEpoch epoch)
    {
        var expected = epoch.DateTimeOffset.ToString(CultureInfo.CurrentCulture);

        var actual = Target(epoch);

        Assert.Equal(expected, actual);
    }
}
