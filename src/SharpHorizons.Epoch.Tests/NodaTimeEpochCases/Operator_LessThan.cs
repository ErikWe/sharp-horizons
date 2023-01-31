namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using Xunit;

public class Operator_LessThan
{
    private static bool Target(Epoch epoch, Epoch other) => epoch < other;

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void NullLHS_False(Epoch other)
    {
        var epoch = Datasets.GetNullEpoch();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void NullRHS_False(Epoch epoch)
    {
        var other = Datasets.GetNullEpoch();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Fact]
    public void NullLHSAndRHS_False()
    {
        var epoch = Datasets.GetNullEpoch();
        var other = Datasets.GetNullEpoch();

        var actual = Target(epoch, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_ValidEpoch))]
    public void Valid_MatchJulianDayComparison(Epoch epoch, Epoch other)
    {
        var expected = epoch.ToJulianDay() < other.ToJulianDay();

        var actual = Target(epoch, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void SameInstance_False(Epoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.False(actual);
    }
}
