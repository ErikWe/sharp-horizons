namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using Xunit;

public class Equals_Epoch
{
    private static bool Target(Epoch epoch, Epoch? other) => epoch.Equals(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Null_False(Epoch epoch)
    {
        var other = Datasets.GetNullEpoch();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_ValidEpoch))]
    public void Valid_MatchInstantEquals(Epoch epoch, Epoch other)
    {
        var expected = epoch.Instant.Equals(other.Instant);

        var actual = Target(epoch, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void SameInstance_True(Epoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.True(actual);
    }
}
