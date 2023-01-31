namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class IEpoch_Difference_IEpoch
{
    private static Time Target(JulianDay julianDay, IEpoch other)
    {
        return execute(julianDay);

        Time execute(IEpoch epoch) => epoch.Difference(other);
    }

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
    public void Convertible_ExactMatchJulianDayDifference(JulianDay julianDay, IEpoch other)
    {
        var expected = julianDay.Difference(other.ToJulianDay());

        var actual = Target(julianDay, other);

        Assert.Equal(expected, actual);
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
