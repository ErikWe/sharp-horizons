namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using Xunit;

public class Operator_Equality
{
    private static bool Target(DateTimeEpoch epoch, DateTimeEpoch? other) => epoch == other;

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void NullLHS_False(DateTimeEpoch other)
    {
        var epoch = Datasets.GetNullDateTimeEpoch();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void NullRHS_False(DateTimeEpoch epoch)
    {
        var other = Datasets.GetNullDateTimeEpoch();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Fact]
    public void NullLHSAndRHS_True()
    {
        var epoch = Datasets.GetNullDateTimeEpoch();

        var actual = Target(epoch, epoch);

        Assert.True(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_ValidDateTimeEpoch))]
    public void Valid_MatchDateTimeEpochEqualsMethod(DateTimeEpoch epoch, DateTimeEpoch other)
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
