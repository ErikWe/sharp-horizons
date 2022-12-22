namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class WithJulianDay
{
    [Theory]
    [ClassData(typeof(Datasets.ConvertibleJulianDays))]
    public void From_Valid_ApproximatelyOffsetByConstant(JulianDay julianDay)
    {
        var expected = julianDay.Day - 2400000.5;

        var actual = ModifiedJulianDay.FromJulianDay(julianDay);

        Asserter.Approximate(expected, actual.Day);
    }

    [Theory]
    [ClassData(typeof(Datasets.UnconvertibleJulianDays))]
    public void From_OutOfRange_ArgumentOutOfRangeException(JulianDay julianDay)
    {
        var exception = Record.Exception(() => ModifiedJulianDay.FromJulianDay(julianDay));

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void From_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => ModifiedJulianDay.FromJulianDay(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDays))]
    public void To_ApproximatelyOffsetByConstant(ModifiedJulianDay modifiedJulianDay)
    {
        var expected = modifiedJulianDay.Day + 2400000.5;

        var actual = modifiedJulianDay.ToJulianDay();

        Asserter.Approximate(expected, actual.Day);
    }

    [Theory]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDays))]
    public void To_OutOfRange_EpochOutOfBoundsException(ModifiedJulianDay modifiedJulianDay)
    {
        var exception = Record.Exception(modifiedJulianDay.ToJulianDay);

        Assert.IsType<EpochOutOfBoundsException>(exception);
    }
}
