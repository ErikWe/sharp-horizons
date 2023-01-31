namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using SharpMeasures;

using System;

using Xunit;

public class Difference_Epoch
{
    private static Time Target(Epoch epoch, Epoch other) => epoch.Difference(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Null_ArgumentNullException(Epoch epoch)
    {
        var other = Datasets.GetNullEpoch();

        var exception = Record.Exception(() => Target(epoch, other));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_ValidEpoch))]
    public void Valid_ExactMatchIEpochDifference(Epoch epoch, Epoch other)
    {
        var expected = epoch.Difference((IEpoch)other);

        var actual = Target(epoch, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void SameInstant_Zero(Epoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.Equal(Time.Zero, actual);
    }
}
