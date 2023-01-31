﻿namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class Operator_Equality
{
    private static bool Target(JulianDay? julianDay, JulianDay? other) => julianDay == other;

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void NullLHS_False(JulianDay other)
    {
        var julianDay = Datasets.GetNullJulianDay();

        var actual = Target(julianDay, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void NullRHS_False(JulianDay julianDay)
    {
        var other = Datasets.GetNullJulianDay();

        var actual = Target(julianDay, other);

        Assert.False(actual);
    }

    [Fact]
    public void NullLHSAndRHS_True()
    {
        var julianDay = Datasets.GetNullJulianDay();

        var actual = Target(julianDay, julianDay);

        Assert.True(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_ValidJulianDay))]
    public void Valid_MatchEqualsMethod(JulianDay julianDay, JulianDay other)
    {
        var expected = julianDay.Equals(other);

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
