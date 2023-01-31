namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using SharpMeasures;

using System;

using Xunit;

public class Difference_DateTimeEpoch
{
    private static Time Target(DateTimeEpoch epoch, DateTimeEpoch other) => epoch.Difference(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Null_ArgumentNullException(DateTimeEpoch epoch)
    {
        var other = Datasets.GetNullDateTimeEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_ValidDateTimeEpoch))]
    public void Valid_ExactMatchIEpochDifference(DateTimeEpoch epoch, DateTimeEpoch other)
    {
        var expected = epoch.Difference((IEpoch)other);

        var actual = Target(epoch, other);

        Assert.Equal(expected, actual);
    }

    private static void AnyError_TException<TException>(DateTimeEpoch epoch, DateTimeEpoch other) where TException : Exception
    {
        var exception = Record.Exception(() => Target(epoch, other));

        Assert.IsType<TException>(exception);
    }
}
