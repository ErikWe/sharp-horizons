namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class CastFromDateTimeOffset
{
    [Theory]
    [ClassData(typeof(Datasets.DateTimeOffsets))]
    public void Valid_ExactMatch(DateTimeOffset offset)
    {
        var actual = (DateTimeEpoch)offset;

        Assert.Equal(offset, actual.DateTimeOffset);
    }
}
