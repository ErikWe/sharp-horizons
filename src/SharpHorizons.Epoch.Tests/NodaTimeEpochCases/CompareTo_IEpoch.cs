namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System;

using Xunit;

public class CompareTo_IEpoch
{
    private static int Target(Epoch epoch, IEpoch other) => epoch.CompareTo(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_UnconvertibleIEpoch))]
    public void Unconvertible_ArgumentException(Epoch epoch, IEpoch other)
    {
        var exception = Record.Exception(() => Target(epoch, other));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Null_Positive(Epoch epoch)
    {
        var other = Datasets.GetNullIEpoch();

        var comparison = Target(epoch, other);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_ValidEpoch))]
    public void Convertible_SameSignAsJulianDayComparison(Epoch epoch, Epoch other)
    {
        var expected = Math.Sign(epoch.ToJulianDay().CompareTo(other));

        var actual = Math.Sign(Target(epoch, other));

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void SameInstance_Zero(Epoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.Equal(0, actual);
    }
}
