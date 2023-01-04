namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class CastFromDouble
{
    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayNumbers))]
    public void Valid_ApproximateMatch(double julianDayNumber)
    {
        var actual = (JulianDay)julianDayNumber;

        Asserter.Approximate(julianDayNumber, actual.Day);
    }

    [Fact]
    public void NaN_ArgumentException()
    {
        var exception = Record.Exception(() => (JulianDay)double.NaN);

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeJulianDayNumbers))]
    public void OutOfRange_ArgumentOutOfRangeException(double julianDayNumber)
    {
        var exception = Record.Exception(() => (JulianDay)julianDayNumber);

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
