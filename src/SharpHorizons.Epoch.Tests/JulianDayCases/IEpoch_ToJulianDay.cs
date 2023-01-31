namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class IEpoch_ToJulianDay
{
    private static JulianDay Target(JulianDay julianDay) => ((IEpoch)julianDay).ToJulianDay();

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void SameInstance(JulianDay julianDay)
    {
        var actual = Target(julianDay);

        Assert.Same(julianDay, actual);
    }
}
