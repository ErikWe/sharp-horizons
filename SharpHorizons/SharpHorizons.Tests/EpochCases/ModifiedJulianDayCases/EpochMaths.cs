namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System.Collections.Generic;

using Xunit;

public class EpochMaths
{
    private static int Precision { get; } = 5;

    [Theory]
    [MemberData(nameof(ModifiedJulianDays))]
    public void ModifiedJulianDayMethod_ApproximateMatch(ModifiedJulianDay initialModifiedJulianDay, ModifiedJulianDay modifiedFinalJulianDay)
    {
        var actual = modifiedFinalJulianDay.Difference(initialModifiedJulianDay);

        Assert.Equal(modifiedFinalJulianDay.Day - initialModifiedJulianDay.Day, actual.Days, Precision);
    }

    [Theory]
    [MemberData(nameof(ModifiedJulianDays))]
    public void ModifiedJulianDayOperator_ApproximateMatch(ModifiedJulianDay initialModifiedJulianDay, ModifiedJulianDay modifiedFinalJulianDay)
    {
        var actual = modifiedFinalJulianDay - initialModifiedJulianDay;

        Assert.Equal(modifiedFinalJulianDay.Day - initialModifiedJulianDay.Day, actual.Days, Precision);
    }

    [Theory]
    [MemberData(nameof(ModifiedJulianDays))]
    public void IEpochMethod_ApproximateMatch(IEpoch initialEpoch, ModifiedJulianDay finalModifiedJulianDay)
    {
        var actual = finalModifiedJulianDay.Difference(initialEpoch);

        Assert.Equal(finalModifiedJulianDay.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    [Theory]
    [MemberData(nameof(ModifiedJulianDays))]
    public void IEpochOperator_ApproximateMatch(IEpoch initialEpoch, ModifiedJulianDay finalModifiedJulianDay)
    {
        var actual = finalModifiedJulianDay - initialEpoch;

        Assert.Equal(finalModifiedJulianDay.ToJulianDay().Day - initialEpoch.ToJulianDay().Day, actual.Days, Precision);
    }

    public static IEnumerable<object[]> ModifiedJulianDays() => new object[][]
    {
        new object[] { new ModifiedJulianDay(0), new ModifiedJulianDay(0) },
        new object[] { new ModifiedJulianDay(1), new ModifiedJulianDay(-1) },
        new object[] { new ModifiedJulianDay(-1), new ModifiedJulianDay(1) }
    };
}
