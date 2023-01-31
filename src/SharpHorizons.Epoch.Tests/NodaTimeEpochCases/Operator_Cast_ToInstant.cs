namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using System;

using Xunit;

public class Operator_Cast_ToInstant
{
    private static Instant Target(Epoch epoch) => (Instant)epoch;

    [Fact]
    public void Null_ArgumentNullException()
    {
        var epoch = Datasets.GetNullEpoch();

        var exception = Record.Exception(() => Target(epoch));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Valid_ExactMatch(Epoch epoch)
    {
        var actual = Target(epoch);

        Assert.Equal(epoch.Instant, actual);
    }
}
