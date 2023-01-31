namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class Epoch
{
    private static JulianDay Target() => JulianDay.Epoch;

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
