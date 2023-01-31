namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using Xunit;

public class ToJulianDay
{
    private static JulianDay Target(Epoch epoch) => epoch.ToJulianDay();

    [Theory]
    [ClassData(typeof(Datasets.EpochAndEquivalentJulianDay))]
    public void Valid_ApproximateMatch(Epoch epoch, JulianDay julianDay)
    {
        var actual = Target(epoch);

        Asserter.ApproximateJulianDay(julianDay, actual);
    }
}
