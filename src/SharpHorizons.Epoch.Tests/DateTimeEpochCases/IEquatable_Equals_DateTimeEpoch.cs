namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class IEquatable_Equals_DateTimeEpoch
{
    private static bool Target(DateTimeEpoch epoch, DateTimeEpoch? other)
    {
        return execute(epoch);

        bool execute(IEquatable<DateTimeEpoch> equatable) => equatable.Equals(other);
    }

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
