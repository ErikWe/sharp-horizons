namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class CastToDateTimeOffset
{
    [Theory]
    [ClassData(typeof(Datasets.DateTimeEpochs))]
    public void Valid(DateTimeEpoch dateTimeEpoch)
    {
        var actual = (DateTimeOffset)dateTimeEpoch;

        Assert.Equal(dateTimeEpoch.DateTimeOffset, actual);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (DateTimeOffset)(DateTimeEpoch)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
