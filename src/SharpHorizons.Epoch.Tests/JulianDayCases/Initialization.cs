namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class Initialization
{
    private static JulianDay Target(int integralDay, float fractionalDay) => new() { IntegralDay = integralDay, FractionalDay = fractionalDay };
    private static JulianDay Target(int integralDay) => new() { IntegralDay = integralDay };

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayIntegralDayInt32_InvalidJulianDayFractionalDayFloat))]
    public void ValidIntegralDayAndInvalidFractionalDay_ArgumentException(int integralDay, float fractionalDay) => AnyError_TException<ArgumentException>(integralDay, fractionalDay);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayIntegralDayInt32_OutOfRangeJulianDayFractionalDayFloat))]
    public void ValidIntegralDayAndOutOfRangeFractionalDay_ArgumentOutOfRangeException(int integralDay, float fractionalDay) => AnyError_TException<ArgumentOutOfRangeException>(integralDay, fractionalDay);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayIntegralDayInt32_ValidJulianDayFractionalDayFloat))]
    public void Valid_ExactMatchIntegralDay(int integralDay, float fractionalDay)
    {
        var actual = Target(integralDay, fractionalDay);

        Assert.Equal(integralDay, actual.IntegralDay);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayIntegralDayInt32_ValidJulianDayFractionalDayFloat))]
    public void Valid_ExactMatchFractionalDay(int integralDay, float fractionalDay)
    {
        var actual = Target(integralDay, fractionalDay);

        Assert.Equal(fractionalDay, actual.FractionalDay);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayIntegralDayInt32))]
    public void JustIntegralDay_ZeroFractionalDay(int integralDay)
    {
        var actual = Target(integralDay);

        Assert.Equal(0, actual.FractionalDay);
    }

    private static void AnyError_TException<TException>(int integralDay, float fractionalDay) where TException : Exception
    {
        var exception = Record.Exception(() => Target(integralDay, fractionalDay));

        Assert.IsType<TException>(exception);
    }
}
