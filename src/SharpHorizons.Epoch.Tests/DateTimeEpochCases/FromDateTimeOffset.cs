namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class FromDateTimeOffset
{
    private static DateTimeEpoch Target(DateTimeOffset dateTimeOffset) => DateTimeEpoch.FromDateTimeOffset(dateTimeOffset);

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeOffset))]
    public void Valid_ExactMatchDateTime(DateTimeOffset dateTimeOffset)
    {
        var actual = Target(dateTimeOffset);

        Assert.Equal(dateTimeOffset.DateTime, actual.DateTime);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeOffset))]
    public void Valid_ExactMatchOffset(DateTimeOffset dateTimeOffset)
    {
        var actual = Target(dateTimeOffset);

        Assert.Equal(dateTimeOffset.Offset, actual.Offset);
    }
}
