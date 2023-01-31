namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using SharpMeasures;

using System;

using Xunit;

public class Difference_IEpoch
{
    private static Time Target(DateTimeEpoch epoch, IEpoch other) => epoch.Difference(other);

    private static int TimePrecision { get; } = 5;

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Null_ArgumentNullException(DateTimeEpoch epoch)
    {
        var other = Datasets.GetNullIEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_UnconvertibleIEpoch))]
    public void Unconvertible_ArgumentException(DateTimeEpoch epoch, IEpoch other) => AnyError_TException<ArgumentException>(epoch, other);

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_ConvertibleIEpoch))]
    public void Convertible_ApproximateMatchJulianDayDifference(DateTimeEpoch epoch, IEpoch other)
    {
        var expected = epoch.ToJulianDay().Difference(other);

        var actual = Target(epoch, other);

        Assert.Equal(expected.Days, actual.Days, TimePrecision);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void SameInstance_Zero(DateTimeEpoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.Equal(Time.Zero, actual);
    }

    private static void AnyError_TException<TException>(DateTimeEpoch epoch, IEpoch other) where TException : Exception
    {
        var exception = Record.Exception(() => Target(epoch, other));

        Assert.IsType<TException>(exception);
    }
}
