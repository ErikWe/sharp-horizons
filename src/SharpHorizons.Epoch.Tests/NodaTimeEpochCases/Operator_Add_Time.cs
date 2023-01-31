namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using SharpMeasures;

using System;

using Xunit;

public class Operator_Add_Time
{
    private static Epoch Target(Epoch epoch, Time difference) => epoch + difference;

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.ValidTimes))]
    public void NullEpoch_ArgumentNullException(Time difference)
    {
        var epoch = Datasets.GetNullEpoch();

        AnyError_TException<ArgumentNullException>(epoch, difference);
    }

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.InvalidTimes))]
    public void InvalidTime_ArgumentException(Time difference)
    {
        var epoch = Datasets.GetValidEpoch();

        AnyError_TException<ArgumentException>(epoch, difference);
    }

    [Fact]
    public void OutOfBounds_EpochOutOfBoundsException()
    {
        var epoch = Datasets.GetValidEpoch();
        var difference = EpochCases.Datasets.GetOutOfBoundsTime();

        AnyError_TException<EpochOutOfBoundsException>(epoch, difference);
    }

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.ValidTimes))]
    public void Valid_ExactMatchAddMethod(Time difference)
    {
        var epoch = Datasets.GetValidEpoch();

        var expected = epoch.Add(difference);

        var actual = Target(epoch, difference);

        Asserter.Approximate(expected, actual);
    }

    private static void AnyError_TException<TException>(Epoch epoch, Time difference) where TException : Exception
    {
        var exception = Record.Exception(() => Target(epoch, difference));

        Assert.IsType<TException>(exception);
    }
}
