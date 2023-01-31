namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class CompareTo_DateTimeEpoch
{
    private static int Target(DateTimeEpoch epoch, DateTimeEpoch other) => epoch.CompareTo(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Null_Positive(DateTimeEpoch epoch)
    {
        var other = Datasets.GetNullDateTimeEpoch();

        var comparison = Target(epoch, other);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_ValidDateTimeEpoch))]
    public void Valid_SameSignAsJulianDayComparison(DateTimeEpoch epoch, DateTimeEpoch other)
    {
        var expected = Math.Sign(epoch.ToJulianDay().CompareTo(other));

        var actual = Math.Sign(Target(epoch, other));

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void SameInstance_Zero(DateTimeEpoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.Equal(0, actual);
    }
}
