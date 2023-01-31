namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class Add
{
    private static ModifiedJulianDay Target(ModifiedJulianDay modifiedJulianDay, Time difference) => modifiedJulianDay.Add(difference);

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
    public void Valid_ApproximateMatch(Time difference)
    {
        var modifiedJulianDay = Datasets.GetConvertibleModifiedJulianDay();

        var expected = modifiedJulianDay.Day + difference.Days;

        var actual = Target(modifiedJulianDay, difference);

        Asserter.Approximate(expected, actual.Day);
    }

    private static void AnyError_TException<TException>(Time difference) where TException : Exception
    {
        var modifiedJulianDay = Datasets.GetConvertibleModifiedJulianDay();

        var exception = Record.Exception(() => Target(modifiedJulianDay, difference));

        Assert.IsType<TException>(exception);
    }
}
