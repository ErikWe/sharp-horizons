namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System.Globalization;

using Xunit;

public class ToStringInvariant
{
    private static string Target(Epoch epoch) => epoch.ToStringInvariant();

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Valid_MatchInstantToStringWithInvariantCulture(Epoch epoch)
    {
        var expected = epoch.Instant.ToString(null, CultureInfo.InvariantCulture);

        var actual = Target(epoch);

        Assert.Equal(expected, actual);
    }
}
