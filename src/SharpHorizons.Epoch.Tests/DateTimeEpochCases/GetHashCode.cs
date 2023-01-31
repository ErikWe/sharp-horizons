namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using Xunit;

public class GetHashCode
{
    private static int Target(DateTimeEpoch epoch) => epoch.GetHashCode();

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Valid_SameIfEqual(DateTimeEpoch epoch)
    {
        DateTimeEpoch other = new(epoch.DateTimeOffset);

        var expected = Target(other);

        var actual = Target(epoch);

        Assert.Equal(expected, actual);
    }
}
