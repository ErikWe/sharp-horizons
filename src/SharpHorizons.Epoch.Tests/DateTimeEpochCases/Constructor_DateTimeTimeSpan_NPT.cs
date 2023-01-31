namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

[Collection("Non-Parallel Collection")]
[SuppressMessage("Usage", "xUnit1033", Justification = "Fixture modifies global state.")]
public class Constructor_DateTimeTimeSpan_NPT : IClassFixture<NPTFixture>
{
    [Theory]
    [ClassData(typeof(Datasets.NPTOutOfRangeCombination_DateTime_Offset))]
    public void OutOfRange_ArgumentOutOfRangeException(DateTime dateTime, TimeSpan offset)
    {
        Constructor_DateTimeTimeSpan.AnyError_TException<ArgumentOutOfRangeException>(dateTime, offset);
    }

    [Theory]
    [ClassData(typeof(Datasets.NPTInvalidDateTime))]
    public void InvalidDateTime_ValidOffset_ArgumentOutOfRangeException(DateTime dateTime)
    {
        var offset = Datasets.GetNPTOffset();

        Constructor_DateTimeTimeSpan.AnyError_TException<ArgumentOutOfRangeException>(dateTime, offset);
    }

    [Theory]
    [ClassData(typeof(Datasets.NPT_ValidDateTime_ValidOffset))]
    public void Valid_ExactMatchDateTime(DateTime dateTime, TimeSpan offset)
    {
        var actual = Constructor_DateTimeTimeSpan.Target(dateTime, offset);

        Assert.Equal(dateTime, actual.DateTime);
    }
}
