namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.Instants))]
    public void Valid_ExactMatch(Instant instant)
    {
        Epoch actual = new(instant);

        Assert.Equal(instant, actual.Instant);
    }
}
