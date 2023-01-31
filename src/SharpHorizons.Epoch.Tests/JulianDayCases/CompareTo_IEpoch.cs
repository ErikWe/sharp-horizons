namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class CompareTo_IEpoch
{
    private static int Target(JulianDay julianDay, IEpoch other) => julianDay.CompareTo(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_UnconvertibleIEpoch))]
    public void Unconvertible_ArgumentException(JulianDay julianDay, IEpoch other)
    {
        var exception = Record.Exception(() => Target(julianDay, other));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Null_Positive(JulianDay julianDay)
    {
        var other = Datasets.GetNullIEpoch();

        var comparison = Target(julianDay, other);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_ConvertibleIEpoch))]
    public void Convertible_SameSignAsJulianDayComparison(JulianDay julianDay, IEpoch other)
    {
        var expected = Math.Sign(julianDay.CompareTo(other.ToJulianDay()));

        var actual = Math.Sign(Target(julianDay, other));

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void SameInstance_Zero(JulianDay julianDay)
    {
        var actual = Target(julianDay, julianDay);

        Assert.Equal(0, actual);
    }
}
