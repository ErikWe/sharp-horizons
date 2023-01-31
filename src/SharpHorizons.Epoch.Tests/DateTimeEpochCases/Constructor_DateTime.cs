namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public static class Constructor_DateTime
{
    public static DateTimeEpoch Target(DateTime dateTime) => new(dateTime);

    public static void AnyError_TException<TException>(DateTime dateTime) where TException : Exception
    {
        var exception = Record.Exception(() => Target(dateTime));

        Assert.IsType<TException>(exception);
    }
}
