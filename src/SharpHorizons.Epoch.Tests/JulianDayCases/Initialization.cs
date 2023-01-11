namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidIntegralAndFractionalDays))]
    public void Valid_ExactMatch(int integralDay, float fractionalDay)
    {
        JulianDay actual = new() { IntegralDay = integralDay, FractionalDay = fractionalDay };

        Asserter.Exact(integralDay, fractionalDay, actual.IntegralDay, actual.FractionalDay);
    }

    [Fact]
    public void NaN_ArgumentException()
    {
        var exception = Record.Exception(() => new JulianDay() { IntegralDay = 0, FractionalDay = float.NaN });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeIntegralAndFractionalDays))]
    public void OutOfRange_ArgumentOutOfRangeException(int integralDay, float fractionalDay)
    {
        var exception = Record.Exception(() => new JulianDay() { IntegralDay = integralDay, FractionalDay = fractionalDay });

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
