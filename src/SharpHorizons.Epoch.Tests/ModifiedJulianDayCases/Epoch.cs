namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class Epoch
{
    private static ModifiedJulianDay Target() => ModifiedJulianDay.Epoch;

    [Fact]
    public void ZeroIntegralDay()
    {
        var actual = Target();

        Assert.Equal(0, actual.IntegralDay);
    }

    [Fact]
    public void ZeroFractionalDay()
    {
        var actual = Target();

        Assert.Equal(0, actual.FractionalDay);
    }
}
