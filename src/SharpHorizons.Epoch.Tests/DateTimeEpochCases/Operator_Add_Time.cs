namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using SharpMeasures;

using System;

using Xunit;

public class Operator_Add_Time
{
    private static DateTimeEpoch Target(DateTimeEpoch epoch, Time difference) => epoch + difference;

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.ValidTimes))]
    public void NullEpoch_ArgumentNullException(Time difference)
    {
        var epoch = Datasets.GetNullDateTimeEpoch();

        AnyError_TException<ArgumentNullException>(epoch, difference);
    }

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.InvalidTimes))]
    public void InvalidTime_ArgumentException(Time difference)
    {
        var epoch = Datasets.GetValidDateTimeEpoch();

        AnyError_TException<ArgumentException>(epoch, difference);
    }

    [Fact]
    public void OutOfBounds_EpochOutOfBoundsException()
    {
        var epoch = Datasets.GetValidDateTimeEpoch();
        var difference = EpochCases.Datasets.GetOutOfBoundsTime();

        AnyError_TException<EpochOutOfBoundsException>(epoch, difference);
    }

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.ValidTimes))]
    public void Valid_ExactMatchAddMethod(Time difference)
    {
        var epoch = Datasets.GetValidDateTimeEpoch();

        var expected = epoch.Add(difference);

        var actual = Target(epoch, difference);

        Asserter.Approximate(expected, actual);
    }

    private static void AnyError_TException<TException>(DateTimeEpoch epoch, Time difference) where TException : Exception
    {
        var exception = Record.Exception(() => Target(epoch, difference));

        Assert.IsType<TException>(exception);
    }
}
