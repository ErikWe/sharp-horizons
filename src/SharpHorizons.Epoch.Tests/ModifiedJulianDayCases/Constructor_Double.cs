namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class Constructor_Double
{
    private static ModifiedJulianDay Target(double modifiedJulianDayNumber) => new(modifiedJulianDayNumber);

    [Theory]
    [ClassData(typeof(Datasets.InvalidModifiedJulianDayDouble))]
    public void Invalid_ArgumentException(double modifiedJulianDayNumber) => AnyError_TException<ArgumentException>(modifiedJulianDayNumber);

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeModifiedJulianDayDouble))]
    public void OutOfRange_ArgumentOutOfRangeException(double modifiedJulianDayNumber) => AnyError_TException<ArgumentOutOfRangeException>(modifiedJulianDayNumber);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayDouble))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayDouble))]
    public void Valid_ApproximateMatch(double modifiedJulianDayNumber)
    {
        var actual = Target(modifiedJulianDayNumber);

        Asserter.Approximate(modifiedJulianDayNumber, actual.Day);
    }

    private static void AnyError_TException<TException>(double modifiedJulianDayNumber) where TException : Exception
    {
        var exception = Record.Exception(() => Target(modifiedJulianDayNumber));

        Assert.IsType<TException>(exception);
    }
}
