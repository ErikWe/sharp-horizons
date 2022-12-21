namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayNumbers))]
    public void Double_Valid_ApproximateMatch(double julianDayNumber)
    {
        JulianDay julianDay = new(julianDayNumber);

        Asserter.Approximate(julianDayNumber, julianDay.Day);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidIntegralAndFractionalDays))]
    public void Pair_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        JulianDay julianDay = new(integralDay, fractionalDay);

        Asserter.Exact(integralDay, fractionalDay, julianDay.IntegralDay, julianDay.FractionalDay);
    }

    [Fact]
    public void Double_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new JulianDay(double.NaN));
    }

    [Fact]
    public void Pair_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new JulianDay(0, float.NaN));
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeJulianDayNumbers))]
    public void Double_OutOfRange_ArgumentOutOfRangeException(double julianDayNumber)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new JulianDay(julianDayNumber));
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void Pair_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new JulianDay(integralDay, fractionalDay));
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidIntegralAndFractionalDays))]
    public void Initialization_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        JulianDay julianDay = new() { IntegralDay = integralDay, FractionalDay = fractionalDay };

        Asserter.Exact(integralDay, fractionalDay, julianDay.IntegralDay, julianDay.FractionalDay);
    }

    [Fact]
    public void Initialization_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new JulianDay() { IntegralDay = 0, FractionalDay = float.NaN });
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void Initialization_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new JulianDay() { IntegralDay = integralDay, FractionalDay = fractionalDay });
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayNumbers))]
    public void CastFromDouble_Valid_ApproximateMatch(double julianDayNumber)
    {
        var julianDay = (JulianDay)julianDayNumber;

        Asserter.Approximate(julianDayNumber, julianDay.Day);
    }

    [Fact]
    public void CastFromDouble_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => (JulianDay)double.NaN);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeJulianDayNumbers))]
    public void CastFromDouble_OutOfRange_ArgumentOutOfRangeException(double julianDayNumber)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => (JulianDay)julianDayNumber);
    }
}
