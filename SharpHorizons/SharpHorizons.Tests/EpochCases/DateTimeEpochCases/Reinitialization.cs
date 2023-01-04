namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.DateTimeOffsets))]
    public void Valid_ExactMatch(DateTimeOffset offset)
    {
        var actual = InitialDateTimeEpoch with { DateTimeOffset = offset };

        Assert.Equal(offset, actual.DateTimeOffset);
    }

    private static DateTimeEpoch InitialDateTimeEpoch => new(DateTimeOffset.MinValue);
}
