namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class Construction
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
    public void Pair_Valid_ExactMatch(int integralDay, float fractionalDay)
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
    public void Pair_NaN_ArgumentException()
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
    public void Pair_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        var exception = Record.Exception(() => new ModifiedJulianDay(integralDay, fractionalDay));

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleIntegralAndFractionalDays))]
    [ClassData(typeof(Datasets.UnconvertibleIntegralAndFractionalDays))]
    public void Initialization_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        ModifiedJulianDay actual = new() { IntegralDay = integralDay, FractionalDay = fractionalDay };

        Asserter.Exact(integralDay, fractionalDay, actual.IntegralDay, actual.FractionalDay);
    }

    [Fact]
    public void Initialization_NaN_ArgumentException()
    {
        var exception = Record.Exception(() => new ModifiedJulianDay() { IntegralDay = 0, FractionalDay = float.NaN });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void Initialization_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        var exception = Record.Exception(() => new ModifiedJulianDay() { IntegralDay = integralDay, FractionalDay = fractionalDay });

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleIntegralAndFractionalDays))]
    [ClassData(typeof(Datasets.UnconvertibleIntegralAndFractionalDays))]
    public void Reinitialization_Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        var actual = ModifiedJulianDay.Epoch with { IntegralDay = integralDay, FractionalDay = fractionalDay };

        Asserter.Exact(integralDay, fractionalDay, actual.IntegralDay, actual.FractionalDay);
    }

    [Fact]
    public void Reinitialization_NaN_ArgumentException()
    {
        var exception = Record.Exception(() => ModifiedJulianDay.Epoch with { IntegralDay = 0, FractionalDay = float.NaN });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void Reinitialization_OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        var exception = Record.Exception(() => ModifiedJulianDay.Epoch with { IntegralDay = integralDay, FractionalDay = fractionalDay });

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayNumbers))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayNumbers))]
    public void CastFromDouble_Valid_ApproximateMatch(double modifiedJulianDayNumber)
    {
        var actual = (ModifiedJulianDay)modifiedJulianDayNumber;

        Asserter.Approximate(modifiedJulianDayNumber, actual.Day);
    }

    [Fact]
    public void CastFromDouble_NaN_ArgumentException()
    {
        var exception = Record.Exception(() => (ModifiedJulianDay)double.NaN);

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeModifiedJulianDayNumbers))]
    public void CastFromDouble_OutOfRange_ArgumentOutOfRangeException(double modifiedJulianDayNumber)
    {
        var exception = Record.Exception(() => (ModifiedJulianDay)modifiedJulianDayNumber);

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
