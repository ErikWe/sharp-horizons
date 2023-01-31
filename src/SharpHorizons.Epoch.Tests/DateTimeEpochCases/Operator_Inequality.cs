namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using Xunit;

public class Operator_Inequality
{
    private static bool Target(DateTimeEpoch epoch, DateTimeEpoch? other) => epoch != other;

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void NullLHS_True(DateTimeEpoch other)
    {
        var epoch = Datasets.GetNullDateTimeEpoch();

        var actual = Target(epoch, other);

        Assert.True(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void NullRHS_True(DateTimeEpoch epoch)
    {
        var other = Datasets.GetNullDateTimeEpoch();

        var actual = Target(epoch, other);

        Assert.True(actual);
    }

    [Fact]
    public void NullLHSAndRHS_False()
    {
        var epoch = Datasets.GetNullDateTimeEpoch();

        var actual = Target(epoch, epoch);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_ValidDateTimeEpoch))]
    public void Valid_OppositeOfEqualsMethod(DateTimeEpoch epoch, DateTimeEpoch other)
    {
        var expected = epoch.Equals(other) is false;

        var actual = Target(epoch, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void SameInstance_False(DateTimeEpoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.False(actual);
    }
}
