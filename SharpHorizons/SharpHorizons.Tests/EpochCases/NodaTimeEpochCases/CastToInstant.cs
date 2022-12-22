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
        var actual = (Epoch)instant;

        Assert.Equal(instant, actual.Instant);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (Instant)(Epoch)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
