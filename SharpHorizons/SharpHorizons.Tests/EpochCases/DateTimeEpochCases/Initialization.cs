namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.DateTimeOffsets))]
    public void Valid_ExactMatch(DateTimeOffset offset)
    {
        DateTimeEpoch actual = new() { DateTimeOffset = offset };

        Assert.Equal(offset, actual.DateTimeOffset);
    }
}
