namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.DateTimeOffsets))]
    public void Constructor_Combined_Valid(DateTimeOffset offset)
    {
        DateTimeEpoch actual = new(offset);

        Assert.Equal(offset, actual.DateTimeOffset);
    }

    [Theory]
    [ClassData(typeof(Datasets.DateTimeOffsets))]
    public void Constructor_Partwise_Valid(DateTimeOffset offset)
    {
        DateTimeEpoch actual = new(offset.DateTime, offset.Offset);

        Assert.Equal(offset, actual.DateTimeOffset);
    }

    [Theory]
    [ClassData(typeof(Datasets.DateTimeOffsets))]
    public void Initialization_Combined_Valid(DateTimeOffset offset)
    {
        DateTimeEpoch actual = new() { DateTimeOffset = offset };

        Assert.Equal(offset, actual.DateTimeOffset);
    }

    [Theory]
    [ClassData(typeof(Datasets.DateTimeOffsets))]
    public void CastFromOffset_Valid(DateTimeOffset offset)
    {
        var actual = (DateTimeEpoch)offset;

        Assert.Equal(offset, actual.DateTimeOffset);
    }
}
