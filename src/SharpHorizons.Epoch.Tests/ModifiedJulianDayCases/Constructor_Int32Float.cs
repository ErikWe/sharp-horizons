namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class Constructor_Int32Float
{
    private static ModifiedJulianDay Target(int integralDay, float fractionalDay) => new(integralDay, fractionalDay);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayIntegralDayInt32_InvalidModifiedJulianDayFractionalDayFloat))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayIntegralDayInt32_InvalidModifiedJulianDayFractionalDayFloat))]
    public void ValidIntegralDayAndInvalidFractionalDay_ArgumentException(int integralDay, float fractionalDay) => AnyError_TException<ArgumentException>(integralDay, fractionalDay);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayIntegralDayInt32_OutOfRangeModifiedJulianDayFractionalDayFloat))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayIntegralDayInt32_OutOfRangeModifiedJulianDayFractionalDayFloat))]
    public void ValidIntegralDayandOutOfRangeFractionalDay_ArgumentOutOfRangeException(int integralDay, float fractionalDay) => AnyError_TException<ArgumentOutOfRangeException>(integralDay, fractionalDay);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayIntegralDayInt32_ValidModifiedJulianDayFractionalDayFloat))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayIntegralDayInt32_ValidModifiedJulianDayFractionalDayFloat))]
    public void Valid_ExactMatchIntegralDay(int integralDay, float fractionalDay)
    {
        var actual = Target(integralDay, fractionalDay);

        Assert.Equal(integralDay, actual.IntegralDay);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayIntegralDayInt32_ValidModifiedJulianDayFractionalDayFloat))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayIntegralDayInt32_ValidModifiedJulianDayFractionalDayFloat))]
    public void Valid_ExactMatchFractionalDay(int integralDay, float fractionalDay)
    {
        var actual = Target(integralDay, fractionalDay);

        Assert.Equal(fractionalDay, actual.FractionalDay);
    }

    private static void AnyError_TException<TException>(int integralDay, float fractionalDay) where TException : Exception
    {
        var exception = Record.Exception(() => Target(integralDay, fractionalDay));

        Assert.IsType<TException>(exception);
    }
}
