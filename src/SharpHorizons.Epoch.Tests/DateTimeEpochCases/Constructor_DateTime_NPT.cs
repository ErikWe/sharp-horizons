namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

[Collection("Non-Parallel Collection")]
[SuppressMessage("Usage", "xUnit1033", Justification = "Fixture modifies global state.")]
public class Constructor_DateTime_NPT : IClassFixture<NPTFixture>
{
    [Theory]
    [ClassData(typeof(Datasets.NPTInvalidDateTime))]
    public void Invalid_ArgumentOutOfRangeException(DateTime dateTime)
    {
        Constructor_DateTime.AnyError_TException<ArgumentOutOfRangeException>(dateTime);
    }

    [Theory]
    [ClassData(typeof(Datasets.NPTValidDateTime))]
    public void Valid_ExactMatchDateTime(DateTime dateTime)
    {
        var actual = Constructor_DateTime.Target(dateTime);

        Assert.Equal(dateTime, actual.DateTime);
    }

    [Theory]
    [ClassData(typeof(Datasets.NPTValidDateTime))]
    public void Valid_ExactMatchOffset(DateTime dateTime)
    {
        var expected = Datasets.GetNPTOffset();

        var actual = Constructor_DateTime.Target(dateTime);

        Assert.Equal(expected, actual.Offset);
    }
}
