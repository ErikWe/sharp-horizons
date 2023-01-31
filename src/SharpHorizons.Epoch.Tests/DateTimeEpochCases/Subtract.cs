namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using SharpMeasures;

using System;

using Xunit;

public class Subtract
{
    private static DateTimeEpoch Target(DateTimeEpoch epoch, Time difference) => epoch.Subtract(difference);

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.InvalidTimes))]
    public void Invalid_ArgumentException(Time difference) => AnyError_TException<ArgumentException>(difference);

    [Fact]
    public void OutOfBounds_EpochOutOfBoundsException()
    {
        var difference = EpochCases.Datasets.GetOutOfBoundsTime();

        AnyError_TException<EpochOutOfBoundsException>(difference);
    }

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.ValidTimes))]
    public void Valid_ApproximateMatchJulianDaySubtract(Time difference)
    {
        var epoch = Datasets.GetValidDateTimeEpoch();

        var expected = DateTimeEpoch.FromJulianDay(epoch.ToJulianDay().Subtract(difference));

        var actual = Target(epoch, difference);

        Asserter.Approximate(expected, actual);
    }

    private static void AnyError_TException<TException>(Time difference) where TException : Exception
    {
        var epoch = Datasets.GetValidDateTimeEpoch();

        var exception = Record.Exception(() => Target(epoch, difference));

        Assert.IsType<TException>(exception);
    }
}
