namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

[Collection("Non-Parallel Collection")]
[SuppressMessage("Usage", "xUnit1033", Justification = "Fixture modifies global state.")]
public class Constructor_DateTime_PST : IClassFixture<PSTFixture>
{
    [Theory]
    [ClassData(typeof(Datasets.PSTInvalidDateTime))]
    public void Invalid_ArgumentOutOfRangeException(DateTime dateTime)
    {
        Constructor_DateTime.AnyError_TException<ArgumentOutOfRangeException>(dateTime);
    }
}
