namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class WithJulianDay
{
    [Theory]
    [ClassData(typeof(Datasets.ConvertibleJulianDays))]
    public void From_Valid_ApproximatelyOffsetByConstant(JulianDay julianDay)
    {
        var actual = ModifiedJulianDay.FromJulianDay(julianDay);

        Asserter.Approximate(julianDay.Day - 2400000.5, actual.Day);
    }

    [Theory]
    [ClassData(typeof(Datasets.UnconvertibleJulianDays))]
    public void From_OutOfRange_ArgumentOutOfRangeException(JulianDay julianDay)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => ModifiedJulianDay.FromJulianDay(julianDay));
    }

    [Fact]
    public void From_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ModifiedJulianDay.FromJulianDay(null!));
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDays))]
    public void To_ApproximatelyOffsetByConstant(ModifiedJulianDay modifiedJulianDay)
    {
        var actual = modifiedJulianDay.ToJulianDay();

        Asserter.Approximate(modifiedJulianDay.Day + 2400000.5, actual.Day);
    }

    [Theory]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDays))]
    public void To_OutOfRange_EpochOutOfBoundsException(ModifiedJulianDay modifiedJulianDay)
    {
        Assert.Throws<EpochOutOfBoundsException>(modifiedJulianDay.ToJulianDay);
    }
}
