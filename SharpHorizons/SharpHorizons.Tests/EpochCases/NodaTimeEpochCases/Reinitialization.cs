namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.Instants))]
    public void Valid_ExactMatch(Instant instant)
    {
        var actual = InitialEpoch with { Instant = instant };

        Assert.Equal(instant, actual.Instant);
    }

    private static Epoch InitialEpoch => Epoch.FromJulianDay(JulianDay.Epoch);
}
