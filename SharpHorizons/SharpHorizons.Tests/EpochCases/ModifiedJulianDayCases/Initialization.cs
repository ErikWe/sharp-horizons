namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.ConvertibleIntegralAndFractionalDays))]
    [ClassData(typeof(Datasets.UnconvertibleIntegralAndFractionalDays))]
    public void Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        ModifiedJulianDay actual = new() { IntegralDay = integralDay, FractionalDay = fractionalDay };

        Asserter.Exact(integralDay, fractionalDay, actual.IntegralDay, actual.FractionalDay);
    }

    [Fact]
    public void NaN_ArgumentException()
    {
        var exception = Record.Exception(() => new ModifiedJulianDay() { IntegralDay = 0, FractionalDay = float.NaN });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        var exception = Record.Exception(() => new ModifiedJulianDay() { IntegralDay = integralDay, FractionalDay = fractionalDay });

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
