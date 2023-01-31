namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class Initialization
{
    private static Epoch Target(Instant instant) => new() { Instant = instant };

    [Theory]
    [ClassData(typeof(Datasets.ValidInstant))]
    public void Valid_ExactMatchInstant(Instant instant)
    {
        var actual = Target(instant);

        Assert.Equal(instant, actual.Instant);
    }
}
