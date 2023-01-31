namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class Operator_Subtract_ModifiedJulianDay
{
    private static Time Target(ModifiedJulianDay modifiedJulianDay, ModifiedJulianDay other) => modifiedJulianDay - other;

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void NullLHS_ArgumentNullException(ModifiedJulianDay other)
    {
        var modifiedJulianDay = Datasets.GetNullModifiedJulianDay();

        AnyError_ArgumentNullException(modifiedJulianDay, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void NullRHS_ArgumentNullException(ModifiedJulianDay modifiedJulianDay)
    {
        var other = Datasets.GetNullModifiedJulianDay();

        AnyError_ArgumentNullException(modifiedJulianDay, other);
    }

    [Fact]
    public void NullLHSAndRHS_ArgumentNullException()
    {
        var modifiedJulianDay = Datasets.GetNullModifiedJulianDay();
        var other = Datasets.GetNullModifiedJulianDay();

        AnyError_ArgumentNullException(modifiedJulianDay, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay))]
    public void Valid_ExactMatchDifference(ModifiedJulianDay modifiedJulianDay, ModifiedJulianDay other)
    {
        var expected = modifiedJulianDay.Difference(other);

        var actual = Target(modifiedJulianDay, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void SameInstance_Zero(ModifiedJulianDay modifiedJulianDay)
    {
        var actual = Target(modifiedJulianDay, modifiedJulianDay);

        Assert.Equal(Time.Zero, actual);
    }

    private static void AnyError_ArgumentNullException(ModifiedJulianDay modifiedJulianDay, ModifiedJulianDay other)
    {
        var exception = Record.Exception(() => Target(modifiedJulianDay, other));

        Assert.IsType<ArgumentNullException>(exception);
    }
}
