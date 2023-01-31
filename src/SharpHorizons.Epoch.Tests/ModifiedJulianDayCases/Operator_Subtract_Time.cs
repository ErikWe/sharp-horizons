namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class Operator_Subtract_Time
{
    private static ModifiedJulianDay Target(ModifiedJulianDay modifiedJulianDay, Time difference) => modifiedJulianDay - difference;

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.ValidTimes))]
    public void NullModifiedJulianDay_ArgumentNullException(Time difference)
    {
        var modifiedJulianDay = Datasets.GetNullModifiedJulianDay();

        AnyError_TException<ArgumentNullException>(modifiedJulianDay, difference);
    }

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.InvalidTimes))]
    public void InvalidTime_ArgumentException(Time difference)
    {
        var modifiedJulianDay = Datasets.GetConvertibleModifiedJulianDay();

        AnyError_TException<ArgumentException>(modifiedJulianDay, difference);
    }

    [Fact]
    public void OutOfBounds_EpochOutOfBoundsException()
    {
        var modifiedJulianDay = Datasets.GetConvertibleModifiedJulianDay();

        var difference = EpochCases.Datasets.GetOutOfBoundsTime();

        AnyError_TException<EpochOutOfBoundsException>(modifiedJulianDay, difference);
    }

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.ValidTimes))]
    public void Valid_ApproximateMatch(Time difference)
    {
        var modifiedJulianDay = Datasets.GetConvertibleModifiedJulianDay();

        var expected = modifiedJulianDay.Day - difference.Days;

        var actual = Target(modifiedJulianDay, difference);

        Asserter.Approximate(expected, actual.Day);
    }

    private static void AnyError_TException<TException>(ModifiedJulianDay modifiedJulianDay, Time difference) where TException : Exception
    {
        var exception = Record.Exception(() => Target(modifiedJulianDay, difference));

        Assert.IsType<TException>(exception);
    }
}
