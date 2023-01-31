namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using Xunit;

public class Equals_DateTimeEpoch
{
    private static bool Target(DateTimeEpoch epoch, DateTimeEpoch? other) => epoch.Equals(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Null_False(DateTimeEpoch epoch)
    {
        var other = Datasets.GetNullDateTimeEpoch();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_ValidDateTimeEpoch))]
    public void Valid_MatchDateTimeOffsetEquals(DateTimeEpoch epoch, DateTimeEpoch other)
    {
        var expected = epoch.DateTimeOffset.Equals(other.DateTimeOffset);

        var actual = Target(epoch, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void SameInstance_True(DateTimeEpoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.True(actual);
    }
}
