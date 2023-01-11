namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.DateTimeOffsets))]
    public void DateTimeOffset_Valid_ExactMatch(DateTimeOffset offset)
    {
        DateTimeEpoch actual = new(offset);

        Assert.Equal(offset, actual.DateTimeOffset);
    }

    [Theory]
    [ClassData(typeof(Datasets.DateTimeOffsets))]
    public void DateTimeAndTimSpan_Valid_ExactMatch(DateTimeOffset offset)
    {
        DateTimeEpoch actual = new(offset.DateTime, offset.Offset);

        Assert.Equal(offset, actual.DateTimeOffset);
    }
}
