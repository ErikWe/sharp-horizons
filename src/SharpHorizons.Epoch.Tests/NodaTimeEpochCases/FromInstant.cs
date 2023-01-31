namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class FromInstant
{
    private static Epoch Target(Instant instant) => Epoch.FromInstant(instant);

    [Theory]
    [ClassData(typeof(Datasets.ValidInstant))]
    public void Valid_ExactMatch(Instant instant)
    {
        var actual = Target(instant);

        Assert.Equal(instant, actual.Instant);
    }
}
