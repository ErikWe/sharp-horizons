namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using SharpMeasures;

using System;

using Xunit;

public class Operator_Subtract_Epoch
{
    private static Time Target(Epoch epoch, Epoch other) => epoch - other;

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void NullLHS_ArgumentNullException(Epoch other)
    {
        var epoch = Datasets.GetNullEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void NullRHS_ArgumentNullException(Epoch epoch)
    {
        var other = Datasets.GetNullEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Fact]
    public void NullLHSAndRHS_ArgumentNullException()
    {
        var epoch = Datasets.GetNullEpoch();
        var other = Datasets.GetNullEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_ValidEpoch))]
    public void Valid_ExactMatchDifference(Epoch epoch, Epoch other)
    {
        var expected = epoch.Difference(other);

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

    private static void AnyError_TException<TException>(Epoch epoch, Epoch other) where TException : Exception
    {
        var exception = Record.Exception(() => Target(epoch, other));

        Assert.IsType<TException>(exception);
    }
}
