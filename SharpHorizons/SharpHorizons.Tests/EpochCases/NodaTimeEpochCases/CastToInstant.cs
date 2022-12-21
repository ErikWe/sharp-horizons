namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using System;

using Xunit;

public class CastToInstant
{
    [Theory]
    [ClassData(typeof(Datasets.Epochs))]
    public void Valid(Instant instant)
    {
        var epoch = (Epoch)instant;

        Assert.Equal(instant, epoch.Instant);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => (Instant)(Epoch)null!);
    }
}
