namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class IComparable_CompareTo_DateTimeEpoch
{
    private static int Target(DateTimeEpoch epoch, DateTimeEpoch other)
    {
        return execute(epoch);

        int execute(IComparable<DateTimeEpoch> comparable) => comparable.CompareTo(other);
    }

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
    public void Valid_ExactMatchDateTimeEpochCompareTo(DateTimeEpoch epoch, DateTimeEpoch other)
    {
        var expected = epoch.CompareTo(other);

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
