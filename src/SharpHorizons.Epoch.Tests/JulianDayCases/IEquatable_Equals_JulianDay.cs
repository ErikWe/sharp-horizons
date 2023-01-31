namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class IEquatable_Equals_JulianDay
{
    private static bool Target(JulianDay julianDay, JulianDay? other)
    {
        return execute(julianDay);

        bool execute(IEquatable<JulianDay> equatable) => equatable.Equals(other);
    }

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
    public void Valid_MatchJulianDayEquals(JulianDay julianDay, JulianDay other)
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
