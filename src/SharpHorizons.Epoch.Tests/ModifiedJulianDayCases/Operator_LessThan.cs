namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class Operator_LessThan
{
    private static bool Target(ModifiedJulianDay modifiedulianDay, ModifiedJulianDay other) => modifiedulianDay < other;

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void NullLHS_False(ModifiedJulianDay other)
    {
        var modifiedJulianDay = Datasets.GetNullModifiedJulianDay();

        var actual = Target(modifiedJulianDay, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void NullRHS_False(ModifiedJulianDay modifiedJulianDay)
    {
        var other = Datasets.GetNullModifiedJulianDay();

        var actual = Target(modifiedJulianDay, other);

        Assert.False(actual);
    }

    [Fact]
    public void NullLHSAndRHS_False()
    {
        var modifiedJulianDay = Datasets.GetNullModifiedJulianDay();
        var other = Datasets.GetNullModifiedJulianDay();

        var actual = Target(modifiedJulianDay, other);

        Assert.False(actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay))]
    public void Valid_MatchDouble(ModifiedJulianDay modifiedJulianDay, ModifiedJulianDay other)
    {
        var expected = modifiedJulianDay.Day < other.Day;

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
