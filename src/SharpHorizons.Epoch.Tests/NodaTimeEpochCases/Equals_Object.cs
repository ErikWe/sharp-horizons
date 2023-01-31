namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using Xunit;

public class Equals_Object
{
    private static bool Target(Epoch epoch, object? other) => epoch.Equals(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Null_False(Epoch epoch)
    {
        var other = Datasets.GetNullJulianDay();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void DifferentType_False(Epoch epoch)
    {
        var other = Datasets.GetValidJulianDay();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_ValidEpoch))]
    public void Valid_MatchEpochEquals(Epoch epoch, Epoch other)
    {
        var expected = epoch.Equals(other);

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
