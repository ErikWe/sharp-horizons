namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using SharpMeasures;

using System;

using Xunit;

public class Difference_IEpoch
{
    private static Time Target(Epoch epoch, IEpoch other) => epoch.Difference(other);

    private static int TimePrecision { get; } = 5;

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void Null_ArgumentNullException(Epoch epoch)
    {
        var other = Datasets.GetNullIEpoch();

        AnyError_TException<ArgumentNullException>(epoch, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_UnconvertibleIEpoch))]
    public void Unconvertible_ArgumentException(Epoch epoch, IEpoch other) => AnyError_TException<ArgumentException>(epoch, other);

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch_ConvertibleIEpoch))]
    public void Convertible_ApproximateMatchJulianDayDifference(Epoch epoch, IEpoch other)
    {
        var expected = epoch.ToJulianDay().Difference(other);

        var actual = Target(epoch, other);

        Assert.Equal(expected.Days, actual.Days, TimePrecision);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidEpoch))]
    public void SameInstant_Zero(Epoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.Equal(Time.Zero, actual);
    }

    private static void AnyError_TException<TException>(Epoch epoch, IEpoch other) where TException : Exception
    {
        var exception = Record.Exception(() => Target(epoch, other));

        Assert.IsType<TException>(exception);
    }
}
