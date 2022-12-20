namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class Misc
{
    [Fact]
    public void Epoch_RepresentsZero()
    {
        Assert.Equal(0, JulianDay.Epoch.Day);

        Assert.Equal(0, JulianDay.Epoch.IntegralDay);
        Assert.Equal(0, JulianDay.Epoch.FractionalDay);
    }

    [Fact]
    public void ToJulianDay_Same()
    {
        var julianDay = ((IEpoch)JulianDay.Epoch).ToJulianDay();

        Assert.Equal(0, julianDay.Day);
    }
}
