namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayNumbers))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayNumbers))]
    public void Double_Valid_ApproximateMatch(double modifiedJulianDayNumber)
    {
        ModifiedJulianDay actual = new(modifiedJulianDayNumber);

        Asserter.Approximate(modifiedJulianDayNumber, actual.Day);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleIntegralAndFractionalDays))]
    [ClassData(typeof(Datasets.UnconvertibleIntegralAndFractionalDays))]
    public void IntAndFloat_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        ModifiedJulianDay actual = new(integralDay, fractionalDay);

        Asserter.Exact(integralDay, fractionalDay, actual.IntegralDay, actual.FractionalDay);
    }

    [Fact]
    public void Double_NaN_ArgumentException()
    {
        var exception = Record.Exception(() => new ModifiedJulianDay(double.NaN));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void IntAndFloat_NaN_ArgumentException()
    {
        var exception = Record.Exception(() => new ModifiedJulianDay(0, float.NaN));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeModifiedJulianDayNumbers))]
    public void Double_OutOfRange_ArgumentOutOfRangeException(double modifiedJulianDayNumber)
    {
        var exception = Record.Exception(() => new ModifiedJulianDay(modifiedJulianDayNumber));

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void IntAndFloat_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        var exception = Record.Exception(() => new ModifiedJulianDay(integralDay, fractionalDay));

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
