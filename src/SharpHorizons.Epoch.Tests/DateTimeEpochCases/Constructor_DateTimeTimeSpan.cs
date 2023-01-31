namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public static class Constructor_DateTimeTimeSpan
{
    public static DateTimeEpoch Target(DateTime dateTime, TimeSpan offset) => new(dateTime, offset);

    public static void AnyError_TException<TException>(DateTime dateTime, TimeSpan offset) where TException : Exception
    {
        var exception = Record.Exception(() => Target(dateTime, offset));

        Assert.IsType<TException>(exception);
    }
}
