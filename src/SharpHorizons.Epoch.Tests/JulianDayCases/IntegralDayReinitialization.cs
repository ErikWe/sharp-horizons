namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class IntegralDayReinitialization
{
    private static JulianDay Target(JulianDay julianDay, int integralDay) => julianDay with { IntegralDay = integralDay };

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayIntegralDayInt32))]
    public void Valid_ExactMatch(int integralDay)
    {
        var initial = Datasets.GetValidJulianDay();

        var actual = Target(initial, integralDay);

        Assert.Equal(integralDay, actual.IntegralDay);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayIntegralDayInt32))]
    public void Valid_OriginalNotModified(int integralDay)
    {
        var initial = Datasets.GetValidJulianDay();

        var expected = initial.IntegralDay;

        Target(initial, integralDay);

        var actual = initial.IntegralDay;

        Assert.Equal(expected, actual);
    }
}
