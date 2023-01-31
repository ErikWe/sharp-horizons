namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using Xunit;

public class IEpoch_ToJulianDay
{
    private static JulianDay Target(IEpoch epoch) => epoch.ToJulianDay();

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Valid_ExactMatchDateTimeEpochToJulianDay(DateTimeEpoch dateTimeEpoch)
    {
        var expected = dateTimeEpoch.ToJulianDay();

        var actual = Target(dateTimeEpoch);

        Assert.Equal(expected, actual);
    }
}
