namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class Operator_Subtract_JulianDay
{
    private static Time Target(JulianDay julianDay, JulianDay other) => julianDay - other;

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void NullLHS_ArgumentNullException(JulianDay other)
    {
        var julianDay = Datasets.GetNullJulianDay();

        AnyError_ArgumentNullException(julianDay, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void NullRHS_ArgumentNullException(JulianDay julianDay)
    {
        var other = Datasets.GetNullJulianDay();

        AnyError_ArgumentNullException(julianDay, other);
    }

    [Fact]
    public void NullLHSAndRHS_ArgumentNullException()
    {
        var julianDay = Datasets.GetNullJulianDay();
        var other = Datasets.GetNullJulianDay();

        AnyError_ArgumentNullException(julianDay, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_ValidJulianDay))]
    public void Valid_ExactMatchDifference(JulianDay julianDay, JulianDay other)
    {
        var expected = julianDay.Difference(other);

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

    private static void AnyError_ArgumentNullException(JulianDay julianDay, JulianDay other)
    {
        var exception = Record.Exception(() => Target(julianDay, other));

        Assert.IsType<ArgumentNullException>(exception);
    }
}
