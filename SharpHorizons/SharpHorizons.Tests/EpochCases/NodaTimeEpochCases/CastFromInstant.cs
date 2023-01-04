namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class CastFromInstant
{
    [Theory]
    [ClassData(typeof(Datasets.Instants))]
    public void Valid_ExactMatch(Instant instant)
    {
        var actual = (Epoch)instant;

        Assert.Equal(instant, actual.Instant);
    }
}
