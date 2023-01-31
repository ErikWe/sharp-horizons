namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class Constructor_Double
{
    private static JulianDay Target(double julianDayNumber) => new(julianDayNumber);

    [Theory]
    [ClassData(typeof(Datasets.InvalidJulianDayDouble))]
    public void Invalid_ArgumentException(double julianDayNumber) => AnyError_TException<ArgumentException>(julianDayNumber);

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeJulianDayDouble))]
    public void OutOfRange_ArgumentOutOfRangeException(double julianDayNumber) => AnyError_TException<ArgumentOutOfRangeException>(julianDayNumber);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayDouble))]
    public void Valid_ApproximateMatch(double julianDayNumber)
    {
        var actual = Target(julianDayNumber);

        Asserter.Approximate(julianDayNumber, actual.Day);
    }

    private static void AnyError_TException<TException>(double julianDayNumber) where TException : Exception
    {
        var exception = Record.Exception(() => Target(julianDayNumber));

        Assert.IsType<TException>(exception);
    }
}
