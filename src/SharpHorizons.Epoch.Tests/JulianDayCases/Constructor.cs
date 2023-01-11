namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayNumbers))]
    public void Double_Valid_ApproximateMatch(double julianDayNumber)
    {
        JulianDay actual = new(julianDayNumber);

        Asserter.Approximate(julianDayNumber, actual.Day);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidIntegralAndFractionalDays))]
    public void IntAndFloat_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        JulianDay actual = new(integralDay, fractionalDay);

        Asserter.Exact(integralDay, fractionalDay, actual.IntegralDay, actual.FractionalDay);
    }

    [Fact]
    public void Double_NaN_ArgumentException()
    {
        var exception = Record.Exception(() => new JulianDay(double.NaN));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void IntAndFloat_NaN_ArgumentException()
    {
        var exception = Record.Exception(() => new JulianDay(0, float.NaN));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeJulianDayNumbers))]
    public void Double_OutOfRange_ArgumentOutOfRangeException(double julianDayNumber)
    {
        var exception = Record.Exception(() => new JulianDay(julianDayNumber));

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void IntAndFloat_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        var exception = Record.Exception(() => new JulianDay(integralDay, fractionalDay));

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
