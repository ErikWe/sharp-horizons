namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class FromZonedDateTime
{
    private static Epoch Target(ZonedDateTime dateTime) => Epoch.FromZonedDateTime(dateTime);

    [Theory]
    [ClassData(typeof(Datasets.ValidZonedDateTime))]
    public void Valid_ExactMatchInstant(ZonedDateTime dateTime)
    {
        var actual = Target(dateTime);

        Assert.Equal(dateTime.ToInstant(), actual.Instant);
    }
}
