namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System;

using Xunit;

public class CompareTo_Epoch
{
    private static int Target(Epoch epoch, Epoch other) => epoch.CompareTo(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Null_Positive(Epoch epoch)
    {
        var other = Datasets.GetNullEpoch();

        var comparison = Target(epoch, other);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_ValidEpoch))]
    public void Valid_SameSignAsInstantComparison(Epoch epoch, Epoch other)
    {
        var expected = Math.Sign(epoch.Instant.CompareTo(other.Instant));

        var actual = Math.Sign(Target(epoch, other));

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void SameInstance_Zero(Epoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.Equal(0, actual);
    }
}
