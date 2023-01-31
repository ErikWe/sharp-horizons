namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

[Collection("Non-Parallel Collection")]
[SuppressMessage("Usage", "xUnit1033", Justification = "Fixture modifies global state.")]
public class Constructor_DateTimeTimeSpan_PST : IClassFixture<PSTFixture>
{
    [Theory]
    [ClassData(typeof(Datasets.PSTOutOfRangeCombination_DateTime_Offset))]
    public void OutOfRange_ArgumentOutOfRangeException(DateTime dateTime, TimeSpan offset) => Constructor_DateTimeTimeSpan.AnyError_TException<ArgumentOutOfRangeException>(dateTime, offset);

    [Theory]
    [ClassData(typeof(Datasets.PSTInvalidDateTime))]
    public void InvalidDateTime_ValidOffset_ArgumentOutOfRangeException(DateTime dateTime)
    {
        var offset = Datasets.GetPSTOffset();

        Constructor_DateTimeTimeSpan.AnyError_TException<ArgumentOutOfRangeException>(dateTime, offset);
    }
}
