namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using Xunit;

public class Operator_Cast_FromZonedDateTime
{
    private static Epoch Target(ZonedDateTime dateTime) => (Epoch)dateTime;

    [Theory]
    [ClassData(typeof(Datasets.ValidZonedDateTime))]
    public void Valid_ExactMatchInstant(ZonedDateTime dateTime)
    {
        var actual = Target(dateTime);

        Assert.Equal(dateTime.ToInstant(), actual.Instant);
    }
}
