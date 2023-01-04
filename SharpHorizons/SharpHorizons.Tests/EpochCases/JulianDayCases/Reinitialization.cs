namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidIntegralAndFractionalDays))]
    public void Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        var actual = InitialJulianDay with { IntegralDay = integralDay, FractionalDay = fractionalDay };

        Asserter.Exact(integralDay, fractionalDay, actual.IntegralDay, actual.FractionalDay);
    }

    [Fact]
    public void NaN_ArgumentException()
    {
        var exception = Record.Exception(() => InitialJulianDay with { FractionalDay = float.NaN });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        var exception = Record.Exception(() => InitialJulianDay with { IntegralDay = integralDay, FractionalDay = fractionalDay });

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    private static JulianDay InitialJulianDay => JulianDay.Epoch;
}
