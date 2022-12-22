namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.Instants))]
    public void Constructor_Valid(Instant instant)
    {
        Epoch actual = new(instant);

        Assert.Equal(instant, actual.Instant);
    }

    [Theory]
    [ClassData(typeof(Datasets.Instants))]
    public void Initialization_Valid(Instant instant)
    {
        Epoch actual = new() { Instant = instant };

        Assert.Equal(instant, actual.Instant);
    }

    [Theory]
    [ClassData(typeof(Datasets.Instants))]
    public void CastFromInstant_Valid(Instant instant)
    {
        var actual = (Epoch)instant;

        Assert.Equal(instant, actual.Instant);
    }
}
