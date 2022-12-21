namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class CastToDateTimeOffset
{
    [Theory]
    [ClassData(typeof(Datasets.DateTimeOffsets))]
    public void Valid(DateTimeOffset offset)
    {
        var epoch = (DateTimeEpoch)offset;

        Assert.Equal(offset, epoch.DateTimeOffset);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => (DateTimeOffset)(DateTimeEpoch)null!);
    }
}
