namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class IntegralDayReinitialization
{
    private static ModifiedJulianDay Target(ModifiedJulianDay modifiedJulianDay, int integralDay) => modifiedJulianDay with { IntegralDay = integralDay };

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayIntegralDayInt32))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayIntegralDayInt32))]
    public void Valid_ExactMatch(int integralDay)
    {
        var initial = Datasets.GetConvertibleModifiedJulianDay();

        var actual = Target(initial, integralDay);

        Assert.Equal(integralDay, actual.IntegralDay);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDayIntegralDayInt32))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDayIntegralDayInt32))]
    public void Valid_OriginalNotModified(int integralDay)
    {
        var initial = Datasets.GetConvertibleModifiedJulianDay();

        var expected = initial.IntegralDay;

        Target(initial, integralDay);

        var actual = initial.IntegralDay;

        Assert.Equal(expected, actual);
    }
}
