namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class DateTimeAccess
{
    private static DateTime Target(DateTimeEpoch epoch) => epoch.DateTime;

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Valid_NoException(DateTimeEpoch epoch)
    {
        var exception = Record.Exception(() => Target(epoch));

        Assert.Null(exception);
    }
}
