namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayNumbers))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayNumbers))]
    public void Combined_Valid_ApproximateMatch(double modifiedJulianDayNumber)
    {
        ModifiedJulianDay modifiedJulianDay = new(modifiedJulianDayNumber);

        Asserter.Approximate(modifiedJulianDayNumber, modifiedJulianDay.Day);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleIntegralAndFractionalDays))]
    [ClassData(typeof(Datasets.UnconvertibleIntegralAndFractionalDays))]
    public void Partwise_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        ModifiedJulianDay modifiedJulianDay = new(integralDay, fractionalDay);

        Asserter.Exact(integralDay, fractionalDay, modifiedJulianDay.IntegralDay, modifiedJulianDay.FractionalDay);
    }

    [Fact]
    public void Combined_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new ModifiedJulianDay(double.NaN));
    }

    [Fact]
    public void Partwise_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new ModifiedJulianDay(0, float.NaN));
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeModifiedJulianDayNumbers))]
    public void Combined_OutOfRange_ArgumentOutOfRangeException(double modifiedJulianDayNumber)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ModifiedJulianDay(modifiedJulianDayNumber));
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void Partwise_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ModifiedJulianDay(integralDay, fractionalDay));
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleIntegralAndFractionalDays))]
    [ClassData(typeof(Datasets.UnconvertibleIntegralAndFractionalDays))]
    public void Initialization_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        ModifiedJulianDay modifiedJulianDay = new() { IntegralDay = integralDay, FractionalDay = fractionalDay };

        Asserter.Exact(integralDay, fractionalDay, modifiedJulianDay.IntegralDay, modifiedJulianDay.FractionalDay);
    }

    [Fact]
    public void Initialization_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new ModifiedJulianDay() { IntegralDay = 0, FractionalDay = float.NaN });
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void Initialization_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ModifiedJulianDay() { IntegralDay = integralDay, FractionalDay = fractionalDay });
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayNumbers))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayNumbers))]
    public void CastFromDouble_Valid_ApproximateMatch(double modifiedJulianDayNumber)
    {
        var modifiedJulianDay = (ModifiedJulianDay)modifiedJulianDayNumber;

        Asserter.Approximate(modifiedJulianDayNumber, modifiedJulianDay.Day);
    }

    [Fact]
    public void CastFromDouble_NaN_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => (ModifiedJulianDay)double.NaN);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeModifiedJulianDayNumbers))]
    public void CastFromDouble_OutOfRange_ArgumentOutOfRangeException(double modifiedJulianDayNumber)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => (ModifiedJulianDay)modifiedJulianDayNumber);
    }
}
