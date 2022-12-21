namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.Instants))]
    public void Constructor_Valid(Instant instant)
    {
        Epoch epoch = new(instant);

        Assert.Equal(instant, epoch.Instant);
    }

    [Theory]
    [ClassData(typeof(Datasets.Instants))]
    public void Initialization_Valid(Instant instant)
    {
        Epoch epoch = new() { Instant = instant };

        Assert.Equal(instant, epoch.Instant);
    }

    [Theory]
    [ClassData(typeof(Datasets.Instants))]
    public void CastFromInstant_Valid(Instant instant)
    {
        var epoch = (Epoch)instant;

        Assert.Equal(instant, epoch.Instant);
    }
}
