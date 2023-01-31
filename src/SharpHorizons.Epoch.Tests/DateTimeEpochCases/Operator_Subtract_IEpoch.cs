namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using SharpMeasures;

using System;

using Xunit;

public class Operator_Subtract_IEpoch
{
    private static Time Target(DateTimeEpoch epoch, IEpoch other) => epoch - other;

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleIEpoch))]
    public void NullLHS_ArgumentNullException(IEpoch other)
    {
        var epoch = Datasets.GetNullDateTimeEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void NullRHS_ArgumentNullException(DateTimeEpoch epoch)
    {
        var other = Datasets.GetNullIEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Fact]
    public void NullLHSAndRHS_ArgumentNullException()
    {
        var epoch = Datasets.GetNullDateTimeEpoch();
        var other = Datasets.GetNullIEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_UnconvertibleIEpoch))]
    public void UnconvertibleRHS_ArgumentException(DateTimeEpoch epoch, IEpoch other) => AnyError_TException<ArgumentException>(epoch, other);

    [Theory]
    [ClassData(typeof(Datasets.UnconvertibleIEpoch))]
    public void NullLHSAndUnconvertibleRHS_ArgumentNullException(IEpoch other)
    {
        var epoch = Datasets.GetNullDateTimeEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_ConvertibleIEpoch))]
    public void Convertible_ExactMatchDifference(DateTimeEpoch epoch, IEpoch other)
    {
        var expected = epoch.Difference(other);

        var actual = Target(epoch, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void SameInstance_Zero(DateTimeEpoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.Equal(Time.Zero, actual);
    }

    private static void AnyError_TException<TException>(DateTimeEpoch epoch, IEpoch other) where TException : Exception
    {
        var exception = Record.Exception(() => Target(epoch, other));

        Assert.IsType<TException>(exception);
    }
}
