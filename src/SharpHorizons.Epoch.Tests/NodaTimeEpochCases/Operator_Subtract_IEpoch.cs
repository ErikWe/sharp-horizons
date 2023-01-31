namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using SharpMeasures;

using System;

using Xunit;

public class Operator_Subtract_IEpoch
{
    private static Time Target(Epoch epoch, IEpoch other) => epoch - other;

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleIEpoch))]
    public void NullLHS_ArgumentNullException(IEpoch other)
    {
        var epoch = Datasets.GetNullEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void NullRHS_ArgumentNullException(Epoch epoch)
    {
        var other = Datasets.GetNullIEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Fact]
    public void NullLHSAndRHS_ArgumentNullException()
    {
        var epoch = Datasets.GetNullEpoch();
        var other = Datasets.GetNullIEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_UnconvertibleIEpoch))]
    public void UnconvertibleRHS_ArgumentException(Epoch epoch, IEpoch other) => AnyError_TException<ArgumentException>(epoch, other);

    [Theory]
    [ClassData(typeof(Datasets.UnconvertibleIEpoch))]
    public void NullLHSAndUnconvertibleRHS_ArgumentNullException(IEpoch other)
    {
        var epoch = Datasets.GetNullEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_ConvertibleIEpoch))]
    public void Convertible_ExactMatchDifference(Epoch epoch, IEpoch other)
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

    private static void AnyError_TException<TException>(Epoch epoch, IEpoch other) where TException : Exception
    {
        var exception = Record.Exception(() => Target(epoch, other));

        Assert.IsType<TException>(exception);
    }
}
