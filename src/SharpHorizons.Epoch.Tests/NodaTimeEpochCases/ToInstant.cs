namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class ToInstant
{
    private static Instant Target(Epoch epoch) => epoch.ToInstant();

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Valid_ExactMatch(Epoch epoch)
    {
        var actual = Target(epoch);

        Assert.Equal(epoch.Instant, actual);
    }
}
