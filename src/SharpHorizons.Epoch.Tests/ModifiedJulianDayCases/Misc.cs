namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class Misc
{
    [Fact]
    public void Epoch_RepresentsZero()
    {
        Assert.Equal(0, ModifiedJulianDay.Epoch.Day);

        Assert.Equal(0, ModifiedJulianDay.Epoch.IntegralDay);
        Assert.Equal(0, ModifiedJulianDay.Epoch.FractionalDay);
    }
}
