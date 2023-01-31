namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using Xunit;

public class Equals_Object
{
    private static bool Target(DateTimeEpoch epoch, object? other) => epoch.Equals(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Null_False(DateTimeEpoch epoch)
    {
        var other = Datasets.GetNullJulianDay();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void DifferentType_False(DateTimeEpoch epoch)
    {
        var other = Datasets.GetValidJulianDay();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_ValidDateTimeEpoch))]
    public void Valid_MatchDateTimeEpochEquals(DateTimeEpoch epoch, DateTimeEpoch other)
    {
        var expected = epoch.Equals(other);

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
