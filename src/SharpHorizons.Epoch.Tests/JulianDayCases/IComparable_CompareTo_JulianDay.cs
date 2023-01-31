namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class IComparable_CompareTo_JulianDay
{
    private static int Target(JulianDay julianDay, JulianDay other)
    {
        return execute(julianDay);

        int execute(IComparable<JulianDay> comparable) => comparable.CompareTo(other);
    }

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
    public void Valid_ExactMatchJulianDayCompareTo(JulianDay julianDay, JulianDay other)
    {
        var expected = julianDay.CompareTo(other);

        var actual = Target(julianDay, other);

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
