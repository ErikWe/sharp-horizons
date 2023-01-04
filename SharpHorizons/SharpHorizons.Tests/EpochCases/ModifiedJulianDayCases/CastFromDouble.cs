namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class CastFromDouble
{
    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayNumbers))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayNumbers))]
    public void Valid_ApproximateMatch(double modifiedJulianDayNumber)
    {
        var actual = (ModifiedJulianDay)modifiedJulianDayNumber;

        Asserter.Approximate(modifiedJulianDayNumber, actual.Day);
    }

    [Fact]
    public void NaN_ArgumentException()
    {
        var exception = Record.Exception(() => (ModifiedJulianDay)double.NaN);

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeModifiedJulianDayNumbers))]
    public void OutOfRange_ArgumentOutOfRangeException(double modifiedJulianDayNumber)
    {
        var exception = Record.Exception(() => (ModifiedJulianDay)modifiedJulianDayNumber);

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
