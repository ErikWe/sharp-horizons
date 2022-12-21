namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class EpochMaths
{
    private static int Precision { get; } = 5;

    [Theory]
    [ClassData(typeof(Datasets.TwoConvertibleModifiedJulianDays))]
    [ClassData(typeof(Datasets.TwoUnconvertibleModifiedJulianDays))]
    public void ModifiedJulianDayMethod_ApproximateMatch(ModifiedJulianDay initialModifiedJulianDay, ModifiedJulianDay finalModifiedJulianDay)
    {
        var actual = finalModifiedJulianDay.Difference(initialModifiedJulianDay);

        Assert.Equal(finalModifiedJulianDay.Day - initialModifiedJulianDay.Day, actual.Days, Precision);
    }

    [Fact]
    public void ModifiedJulianDayMethod_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ModifiedJulianDay.Epoch.Difference(null!));
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDaysAndIEpochs))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDaysAndConvertibleIEpochs))]
    public void IEpochMethod_Valid_ApproximateMatch(ModifiedJulianDay finalModifiedJulianDay, IEpoch initialEpoch)
    {
        var actual = finalModifiedJulianDay.Difference(initialEpoch);

        Assert.Equal(finalModifiedJulianDay.Day + 2400000.5 - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoConvertibleModifiedJulianDays))]
    [ClassData(typeof(Datasets.TwoUnconvertibleModifiedJulianDays))]
    public void IEpochMethod_WithModifiedJulianDay_ApproximateMatch(ModifiedJulianDay initialModifiedJulianDay, ModifiedJulianDay finalModifiedJulianDay)
    {
        var actual = finalModifiedJulianDay.Difference((IEpoch)initialModifiedJulianDay);

        Assert.Equal(finalModifiedJulianDay.Day - initialModifiedJulianDay.Day, actual.Days, Precision);
    }

    [Fact]
    public void IEpochMethod_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ModifiedJulianDay.Epoch.Difference(null!));
    }

    [Theory]
    [ClassData(typeof(Datasets.TwoConvertibleModifiedJulianDays))]
    [ClassData(typeof(Datasets.TwoUnconvertibleModifiedJulianDays))]
    public void Operator_ApproximateMatch(ModifiedJulianDay initialModifiedJulianDay, ModifiedJulianDay finalModifiedJulianDay)
    {
        var actual = finalModifiedJulianDay - initialModifiedJulianDay;

        Assert.Equal(finalModifiedJulianDay.Day - initialModifiedJulianDay.Day, actual.Days, Precision);
    }

    [Fact]
    public void Operator_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ModifiedJulianDay.Epoch - null!);
    }
}
