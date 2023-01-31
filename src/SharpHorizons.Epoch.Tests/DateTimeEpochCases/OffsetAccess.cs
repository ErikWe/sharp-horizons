namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class OffsetAccess
{
    private static TimeSpan Target(DateTimeEpoch epoch) => epoch.Offset;

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Valid_NoException(DateTimeEpoch epoch)
    {
        var exception = Record.Exception(() => Target(epoch));

        Assert.Null(exception);
    }
}
