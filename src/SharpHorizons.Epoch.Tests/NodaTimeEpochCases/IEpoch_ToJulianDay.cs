namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using Xunit;

public class IEpoch_ToJulianDay
{
    private static JulianDay Target(IEpoch epoch) => epoch.ToJulianDay();

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Valid_ExactMatchEpochToJulianDay(Epoch epoch)
    {
        var expected = epoch.ToJulianDay();

        var actual = Target(epoch);

        Assert.Equal(expected, actual);
    }
}
