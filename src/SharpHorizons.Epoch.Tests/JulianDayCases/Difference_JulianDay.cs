namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class Difference_JulianDay
{
    private static Time Target(JulianDay julianDay, JulianDay other) => julianDay.Difference(other);

    private static int TimePrecision { get; } = 5;

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Null_ArgumentNullException(JulianDay julianDay)
    {
        var other = Datasets.GetNullJulianDay();

        var exception = Record.Exception(() => Target(julianDay, other));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_ValidJulianDay))]
    public void Valid_ApproximateMatch(JulianDay julianDay, JulianDay other)
    {
        var expected = julianDay.Day - other.Day;

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
}
