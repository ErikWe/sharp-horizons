namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class CompareTo_JulianDay
{
    private static int Target(JulianDay julianDay, JulianDay other) => julianDay.CompareTo(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Null_Positive(JulianDay julianDay)
    {
        var other = Datasets.GetNullJulianDay();

        var comparison = Target(julianDay, other);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_ValidJulianDay))]
    public void Valid_SameSignAsDoubleComparison(JulianDay julianDay, JulianDay other)
    {
        var expected = Math.Sign(julianDay.Day.CompareTo(other.Day));

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
