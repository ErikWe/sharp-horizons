namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class Operator_Add_Time
{
    private static JulianDay Target(JulianDay julianDay, Time difference) => julianDay + difference;

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.ValidTimes))]
    public void NullJulianDay_ArgumentNullException(Time difference)
    {
        var julianDay = Datasets.GetNullJulianDay();

        AnyError_TException<ArgumentNullException>(julianDay, difference);
    }

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.InvalidTimes))]
    public void InvalidTime_ArgumentException(Time difference)
    {
        var julianDay = Datasets.GetValidJulianDay();

        AnyError_TException<ArgumentException>(julianDay, difference);
    }

    [Fact]
    public void OutOfBounds_EpochOutOfBoundsException()
    {
        var julianDay = Datasets.GetValidJulianDay();

        var difference = EpochCases.Datasets.GetOutOfBoundsTime();

        AnyError_TException<EpochOutOfBoundsException>(julianDay, difference);
    }

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.ValidTimes))]
    public void Valid_ApproximateMatch(Time difference)
    {
        var julianDay = Datasets.GetValidJulianDay();

        var expected = julianDay.Day + difference.Days;

        var actual = Target(julianDay, difference);

        Asserter.Approximate(expected, actual.Day);
    }

    private static void AnyError_TException<TException>(JulianDay julianDay, Time difference) where TException : Exception
    {
        var exception = Record.Exception(() => Target(julianDay, difference));

        Assert.IsType<TException>(exception);
    }
}
