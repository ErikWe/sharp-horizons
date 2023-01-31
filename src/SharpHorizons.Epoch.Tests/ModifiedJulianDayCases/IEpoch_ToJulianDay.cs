namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class IEpoch_ToJulianDay
{
    private static JulianDay Target(IEpoch epoch) => epoch.ToJulianDay();

    [Theory]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Unconvertible_EpochOutOfBoundsException(ModifiedJulianDay modifiedJulianDay)
    {
        var exception = Record.Exception(() => Target(modifiedJulianDay));

        Assert.IsType<EpochOutOfBoundsException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    public void Convertible_ExactMatchModifiedJulianDayToJulianDay(ModifiedJulianDay modifiedJulianDay)
    {
        var expected = modifiedJulianDay.ToJulianDay();

        var actual = Target(modifiedJulianDay);

        Assert.Equal(expected, actual);
    }
}
