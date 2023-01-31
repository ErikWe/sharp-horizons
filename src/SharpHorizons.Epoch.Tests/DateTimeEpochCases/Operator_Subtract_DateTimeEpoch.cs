namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using SharpMeasures;

using System;

using Xunit;

public class Operator_Subtract_DateTimeEpoch
{
    private static Time Target(DateTimeEpoch epoch, DateTimeEpoch other) => epoch - other;

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void NullLHS_ArgumentNullException(DateTimeEpoch other)
    {
        var epoch = Datasets.GetNullDateTimeEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void NullRHS_ArgumentNullException(DateTimeEpoch epoch)
    {
        var other = Datasets.GetNullDateTimeEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Fact]
    public void NullLHSAndRHS_ArgumentNullException()
    {
        var epoch = Datasets.GetNullDateTimeEpoch();
        var other = Datasets.GetNullDateTimeEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_ValidDateTimeEpoch))]
    public void Valid_ExactMatchDifference(DateTimeEpoch epoch, DateTimeEpoch other)
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

    private static void AnyError_TException<TException>(DateTimeEpoch epoch, DateTimeEpoch other) where TException : Exception
    {
        var exception = Record.Exception(() => Target(epoch, other));

        Assert.IsType<TException>(exception);
    }
}
