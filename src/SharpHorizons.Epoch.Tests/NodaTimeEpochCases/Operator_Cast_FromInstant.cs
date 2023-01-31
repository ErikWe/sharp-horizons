namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class Operator_Cast_FromInstant
{
    private static Epoch Target(Instant instant) => (Epoch)instant;

    [Theory]
    [ClassData(typeof(Datasets.ValidInstant))]
    public void Valid_ExactMatch(Instant instant)
    {
        var actual = Target(instant);

        Assert.Equal(instant, actual.Instant);
    }
}
