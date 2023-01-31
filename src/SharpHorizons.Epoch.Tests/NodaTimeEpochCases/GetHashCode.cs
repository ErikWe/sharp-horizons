namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using Xunit;

public class GetHashCode
{
    private static int Target(Epoch epoch) => epoch.GetHashCode();

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Valid_SameIfEqual(Epoch epoch)
    {
        Epoch other = new(epoch.Instant);

        var expected = Target(other);

        var actual = Target(epoch);

        Assert.Equal(expected, actual);
    }
}
