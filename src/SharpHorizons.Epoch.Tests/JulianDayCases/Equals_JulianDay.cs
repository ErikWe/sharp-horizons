﻿namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class Equals_JulianDay
{
    private static bool Target(JulianDay julianDay, JulianDay? other) => julianDay.Equals(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Null_False(JulianDay julianDay)
    {
        var other = Datasets.GetNullJulianDay();

        var actual = Target(julianDay, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_ValidJulianDay))]
    public void Valid_MatchDoubleEquals(JulianDay julianDay, JulianDay other)
    {
        var expected = julianDay.Day.Equals(other.Day);

        var actual = Target(julianDay, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void SameInstance_True(JulianDay julianDay)
    {
        var actual = Target(julianDay, julianDay);

        Assert.True(actual);
    }
}
