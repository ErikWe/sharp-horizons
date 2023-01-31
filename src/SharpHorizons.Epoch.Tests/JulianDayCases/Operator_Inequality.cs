namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class Operator_Inequality
{
    private static bool Target(JulianDay? julianDay, JulianDay? other) => julianDay != other;

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void NullLHS_True(JulianDay other)
    {
        var julianDay = Datasets.GetNullJulianDay();

        var actual = Target(julianDay, other);

        Assert.True(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void NullRHS_True(JulianDay julianDay)
    {
        var other = Datasets.GetNullJulianDay();

        var actual = Target(julianDay, other);

        Assert.True(actual);
    }

    [Fact]
    public void NullLHSAndRHS_False()
    {
        var julianDay = Datasets.GetNullJulianDay();

        var actual = Target(julianDay, julianDay);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_ValidJulianDay))]
    public void Valid_OppositeOfEqualsMethod(JulianDay julianDay, JulianDay other)
    {
        var expected = julianDay.Equals(other) is false;

        var actual = Target(julianDay, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void SameInstance_False(JulianDay julianDay)
    {
        var actual = Target(julianDay, julianDay);

        Assert.False(actual);
    }
}
