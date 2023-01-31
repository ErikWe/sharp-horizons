namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class InstantReinitialization
{
    private static Epoch Target(Epoch epoch, Instant instant) => epoch with { Instant = instant };

    [Theory]
    [ClassData(typeof(Datasets.ValidInstant))]
    public void Valid_ExactMatch(Instant instant)
    {
        var initial = Datasets.GetValidEpoch();

        var actual = Target(initial, instant);

        Assert.Equal(instant, actual.Instant);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidInstant))]
    public void Valid_OriginalNotModified(Instant instant)
    {
        var initial = Datasets.GetValidEpoch();

        var expected = initial.Instant;

        Target(initial, instant);

        var actual = initial.Instant;

        Assert.Equal(expected, actual);
    }
}
