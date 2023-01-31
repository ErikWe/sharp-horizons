namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class Difference_IEpoch
{
    private static Time Target(JulianDay julianDay, IEpoch other) => julianDay.Difference(other);

    private static int TimePrecision { get; } = 4;

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Null_ArgumentNullException(JulianDay julianDay)
    {
        var other = Datasets.GetNullIEpoch();

        AnyError_TException<ArgumentNullException>(julianDay, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_UnconvertibleIEpoch))]
    public void Unconvertible_ArgumentException(JulianDay julianDay, IEpoch other) => AnyError_TException<ArgumentException>(julianDay, other);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_ConvertibleIEpoch))]
    public void Convertible_ApproximateMatchJulianDayDifference(JulianDay julianDay, IEpoch other)
    {
        var expected = julianDay.Day - other.ToJulianDay().Day;

        var actual = Target(julianDay, other);

        Assert.Equal(expected, actual.Days, TimePrecision);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void SameInstance_Zero(JulianDay julianDay)
    {
        var actual = Target(julianDay, julianDay);

        Assert.Equal(Time.Zero, actual);
    }

    private static void AnyError_TException<TException>(JulianDay julianDay, IEpoch other) where TException : Exception
    {
        var exception = Record.Exception(() => Target(julianDay, other));

        Assert.IsType<TException>(exception);
    }
}
