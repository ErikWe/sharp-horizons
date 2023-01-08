namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ConvertibleIntegralAndFractionalDays))]
    [ClassData(typeof(Datasets.UnconvertibleIntegralAndFractionalDays))]
    public void Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        var actual = InitialModifiedJulianDay with { IntegralDay = integralDay, FractionalDay = fractionalDay };

        Asserter.Exact(integralDay, fractionalDay, actual.IntegralDay, actual.FractionalDay);
    }

    [Fact]
    public void NaN_ArgumentException()
    {
        var exception = Record.Exception(() => InitialModifiedJulianDay with { IntegralDay = 0, FractionalDay = float.NaN });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        var exception = Record.Exception(() => InitialModifiedJulianDay with { IntegralDay = integralDay, FractionalDay = fractionalDay });

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    private static ModifiedJulianDay InitialModifiedJulianDay => ModifiedJulianDay.Epoch;
}
