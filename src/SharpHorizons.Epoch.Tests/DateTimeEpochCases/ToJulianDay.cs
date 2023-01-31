namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using Xunit;

public class ToJulianDay
{
    private static JulianDay Target(DateTimeEpoch epoch) => epoch.ToJulianDay();

    [Theory]
    [ClassData(typeof(Datasets.DateTimeEpochAndEquivalentJulianDay))]
    public void Valid_ApproximateMatch(DateTimeEpoch epoch, JulianDay julianDay)
    {
        var actual = Target(epoch);

        Asserter.ApproximateJulianDay(julianDay, actual);
    }
}
