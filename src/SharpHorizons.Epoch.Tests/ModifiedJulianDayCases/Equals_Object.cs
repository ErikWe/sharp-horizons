namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class Equals_Object
{
    private static bool Target(ModifiedJulianDay modifiedJulianDay, object? other) => modifiedJulianDay.Equals(other);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Null_False(ModifiedJulianDay modifiedJulianDay)
    {
        var other = Datasets.GetNullJulianDay();

        var actual = Target(modifiedJulianDay, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void DifferentType_False(ModifiedJulianDay modifiedJulianDay)
    {
        var other = Datasets.GetValidJulianDay();

        var actual = Target(modifiedJulianDay, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay))]
    public void Valid_MatchModifiedJulianDayEquals(ModifiedJulianDay modifiedJulianDay, ModifiedJulianDay other)
    {
        var expected = modifiedJulianDay.Equals(other);

        var actual = Target(modifiedJulianDay, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void SameInstance_True(ModifiedJulianDay modifiedJulianDay)
    {
        var actual = Target(modifiedJulianDay, modifiedJulianDay);

        Assert.True(actual);
    }
}
