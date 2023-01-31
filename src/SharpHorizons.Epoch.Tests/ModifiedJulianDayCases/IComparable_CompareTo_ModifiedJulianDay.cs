namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class IComparable_CompareTo_ModifiedJulianDay
{
    private static int Target(ModifiedJulianDay modifiedJulianDay, ModifiedJulianDay other)
    {
        return execute(modifiedJulianDay);

        int execute(IComparable<ModifiedJulianDay> comparable) => comparable.CompareTo(other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Null_Positive(ModifiedJulianDay julianDay)
    {
        var other = Datasets.GetNullModifiedJulianDay();

        var comparison = Target(julianDay, other);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay))]
    public void Valid_ExactMatchModifiedJulianDayCompareTo(ModifiedJulianDay modifiedJulianDay, ModifiedJulianDay other)
    {
        var expected = modifiedJulianDay.CompareTo(other);

        var actual = Target(modifiedJulianDay, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void SameInstance_Zero(ModifiedJulianDay modifiedJulianDay)
    {
        var actual = Target(modifiedJulianDay, modifiedJulianDay);

        Assert.Equal(0, actual);
    }
}
