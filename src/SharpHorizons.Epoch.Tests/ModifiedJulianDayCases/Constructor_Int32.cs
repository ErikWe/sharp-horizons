namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class Constructor_Int32
{
    private static ModifiedJulianDay Target(int integralDay) => new(integralDay);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayIntegralDayInt32))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayIntegralDayInt32))]
    public void Valid_ExactMatchIntegralDay(int integralDay)
    {
        var actual = Target(integralDay);

        Assert.Equal(integralDay, actual.IntegralDay);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayIntegralDayInt32))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayIntegralDayInt32))]
    public void Valid_ZeroFractionalDay(int integralDay)
    {
        var actual = Target(integralDay);

        Assert.Equal(0, actual.FractionalDay);
    }
}
