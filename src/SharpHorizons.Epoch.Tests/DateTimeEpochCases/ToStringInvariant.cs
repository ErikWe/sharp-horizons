namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System.Globalization;

using Xunit;

public class ToStringInvariant
{
    private static string Target(DateTimeEpoch epoch) => epoch.ToStringInvariant();

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Valid_MatchDateTimeOffsetToStringWithInvariantCulture(DateTimeEpoch epoch)
    {
        var expected = epoch.DateTimeOffset.ToString(CultureInfo.InvariantCulture);

        var actual = Target(epoch);

        Assert.Equal(expected, actual);
    }
}
