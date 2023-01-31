namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class Constructor_Int32
{
    private static JulianDay Target(int integralDay) => new(integralDay);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayIntegralDayInt32))]
    public void Valid_ExactMatchIntegralDay(int integralDay)
    {
        var actual = Target(integralDay);

        Assert.Equal(integralDay, actual.IntegralDay);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayIntegralDayInt32))]
    public void Valid_ZeroFractionalDay(int integralDay)
    {
        var actual = Target(integralDay);

        Assert.Equal(0, actual.FractionalDay);
    }
}
