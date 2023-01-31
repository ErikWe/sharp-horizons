﻿namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using Xunit;

public class Operator_Equality
{
    private static bool Target(Epoch epoch, Epoch? other) => epoch == other;

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void NullLHS_False(Epoch other)
    {
        var epoch = Datasets.GetNullEpoch();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void NullRHS_False(Epoch epoch)
    {
        var other = Datasets.GetNullEpoch();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Fact]
    public void NullLHSAndRHS_True()
    {
        var epoch = Datasets.GetNullEpoch();

        var actual = Target(epoch, epoch);

        Assert.True(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_ValidEpoch))]
    public void Valid_MatchEpochEqualsMethod(Epoch epoch, Epoch other)
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