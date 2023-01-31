namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class Constructor_Instant
{
    private static Epoch Target(Instant instant) => new(instant);

    [Theory]
    [ClassData(typeof(Datasets.ValidInstant))]
    public void Valid_ExactMatch(Instant instant)
    {
        var actual = Target(instant);

        Assert.Equal(instant, actual.Instant);
    }
}
