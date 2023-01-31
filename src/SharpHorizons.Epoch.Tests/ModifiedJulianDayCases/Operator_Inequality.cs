namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class Operator_Inequality
{
    private static bool Target(ModifiedJulianDay? modifiedJulianDay, ModifiedJulianDay? other) => modifiedJulianDay != other;

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void NullLHS_True(ModifiedJulianDay other)
    {
        var modifiedJulianDay = Datasets.GetNullModifiedJulianDay();

        var actual = Target(modifiedJulianDay, other);

        Assert.True(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void NullRHS_True(ModifiedJulianDay modifiedJulianDay)
    {
        var other = Datasets.GetNullModifiedJulianDay();

        var actual = Target(modifiedJulianDay, other);

        Assert.True(actual);
    }

    [Fact]
    public void NullLHSAndRHS_False()
    {
        var modifiedJulianDay = Datasets.GetNullModifiedJulianDay();

        var actual = Target(modifiedJulianDay, modifiedJulianDay);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay))]
    public void Valid_OppositeOfEqualsMethod(ModifiedJulianDay modifiedJulianDay, ModifiedJulianDay other)
    {
        var expected = modifiedJulianDay.Equals(other) is false;

        var actual = Target(modifiedJulianDay, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void SameInstance_False(ModifiedJulianDay modifiedJulianDay)
    {
        var actual = Target(modifiedJulianDay, modifiedJulianDay);

        Assert.False(actual);
    }
}
