namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class Operator_Cast_ToDouble
{
    private static double Target(ModifiedJulianDay modifiedJulianDay) => (double)modifiedJulianDay;

    [Fact]
    public void Null_ArgumentNullException()
    {
        var modifiedJulianDay = Datasets.GetNullModifiedJulianDay();

        var exception = Record.Exception(() => Target(modifiedJulianDay));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Valid_ExactMatch(ModifiedJulianDay modifiedJulianDay)
    {
        var actual = Target(modifiedJulianDay);

        Assert.Equal(modifiedJulianDay.Day, actual);
    }
}
