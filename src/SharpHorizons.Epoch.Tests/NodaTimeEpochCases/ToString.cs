namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString
{
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString().")]
    private static string Target(Epoch epoch) => epoch.ToString();

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Valid_MatchInstantToStringWithCurrentCulture(Epoch epoch)
    {
        var expected = epoch.Instant.ToString(null, CultureInfo.CurrentCulture);

        var actual = Target(epoch);

        Assert.Equal(expected, actual);
    }
}
