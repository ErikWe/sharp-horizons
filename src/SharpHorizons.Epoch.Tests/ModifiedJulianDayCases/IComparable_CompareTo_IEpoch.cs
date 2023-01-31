namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class IComparable_CompareTo_IEpoch
{
    private static int Target(ModifiedJulianDay modifiedJulianDay, IEpoch other)
    {
        return execute(modifiedJulianDay);

        int execute(IComparable<IEpoch> comparable) => comparable.CompareTo(other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_UnconvertibleIEpoch))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_UnconvertibleIEpoch))]
    public void Unconvertible_ArgumentException(ModifiedJulianDay modifiedJulianDay, IEpoch other)
    {
        var exception = Record.Exception(() => Target(modifiedJulianDay, other));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Null_Positive(ModifiedJulianDay julianDay)
    {
        var other = Datasets.GetNullIEpoch();

        var comparison = Target(julianDay, other);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_ConvertibleIEpoch))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_ConvertibleIEpoch))]
    public void Convertible_ExactMatchModifiedJulianDayCompareTo(ModifiedJulianDay julianDay, IEpoch other)
    {
        var expected = julianDay.CompareTo(other);

        var actual = Target(julianDay, other);

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
