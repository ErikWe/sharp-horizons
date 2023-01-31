namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class Constructor_DateTimeTimeSpan_UTC
{
    [Theory]
    [ClassData(typeof(Datasets.UTCInvalidCombination_DateTime_Offset))]
    public void Invalid_ArgumentException(DateTime dateTime, TimeSpan offset) => Constructor_DateTimeTimeSpan.AnyError_TException<ArgumentException>(dateTime, offset);

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeOffset))]
    public void OutOfRangeOffset_ArgumentOutOfRangeException(TimeSpan offset)
    {
        var dateTime = Datasets.GetValidDateTime();

        Constructor_DateTimeTimeSpan.AnyError_TException<ArgumentOutOfRangeException>(dateTime, offset);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidOffset))]
    public void InvalidOffset_ArgumentException(TimeSpan offset)
    {
        var dateTime = Datasets.GetValidDateTime();

        Constructor_DateTimeTimeSpan.AnyError_TException<ArgumentException>(dateTime, offset);
    }

    [Theory]
    [ClassData(typeof(Datasets.UTCValidCombination_DateTime_Offset))]
    public void Valid_ExactMatchDateTime(DateTime dateTime, TimeSpan offset)
    {
        var actual = Constructor_DateTimeTimeSpan.Target(dateTime, offset);

        Assert.Equal(dateTime, actual.DateTime);
    }

    [Theory]
    [ClassData(typeof(Datasets.UTCValidCombination_DateTime_Offset))]
    public void Valid_ZeroOffset(DateTime dateTime, TimeSpan offset)
    {
        var actual = Constructor_DateTimeTimeSpan.Target(dateTime, offset);

        Assert.Equal(TimeSpan.Zero, actual.Offset);
    }
}
