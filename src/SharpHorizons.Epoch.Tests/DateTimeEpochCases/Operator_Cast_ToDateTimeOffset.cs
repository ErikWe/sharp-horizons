namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class Operator_Cast_ToDateTimeOffset
{
    private static DateTimeOffset Target(DateTimeEpoch epoch) => (DateTimeOffset)epoch;

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Valid_ExactMatchDateTime(DateTimeEpoch epoch)
    {
        var expected = epoch.DateTime;

        var actual = Target(epoch);

        Assert.Equal(expected, actual.DateTime);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Valid_ExactMatchOffset(DateTimeEpoch epoch)
    {
        var expected = epoch.Offset;

        var actual = Target(epoch);

        Assert.Equal(expected, actual.Offset);
    }
}
