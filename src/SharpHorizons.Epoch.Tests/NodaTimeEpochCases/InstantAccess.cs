namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class InstantAccess
{
    private static Instant Target(Epoch epoch) => epoch.Instant;

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Valid_NoException(Epoch epoch)
    {
        var exception = Record.Exception(() => Target(epoch));

        Assert.Null(exception);
    }
}
