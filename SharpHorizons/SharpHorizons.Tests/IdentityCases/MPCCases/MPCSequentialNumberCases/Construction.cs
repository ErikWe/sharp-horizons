namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumberInts))]
    public void Valid_ExactMatch(int number)
    {
        MPCSequentialNumber actual = new(number);

        Assert.Equal(number, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumberInts))]
    public void Invalid_ArgumentOutOfRangeException(int number)
    {
        var exception = Record.Exception(() => new MPCSequentialNumber(number));

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumberInts))]
    public void Initialization_Valid_ExactMatch(int number)
    {
        MPCSequentialNumber actual = new() { Value = number };

        Assert.Equal(number, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumberInts))]
    public void Initialization_Invalid_ArgumentOutOfRangeException(int number)
    {
        var exception = Record.Exception(() => new MPCSequentialNumber() { Value = number });

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumberInts))]
    public void Reinitialization_Valid_ExactMatch(int number)
    {
        var actual = new MPCSequentialNumber(1) with { Value = number };

        Assert.Equal(number, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumberInts))]
    public void Renitialization_Invalid_ArgumentOutOfRangeException(int number)
    {
        var exception = Record.Exception(() => new MPCSequentialNumber(1) with { Value = number });

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumberInts))]
    public void CastFromInt_Valid_ExactMatch(int number)
    {
        var actual = (MPCSequentialNumber)number;

        Assert.Equal(number, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumberInts))]
    public void CastFromInt_Invalid_ArgumentOutOfRangeException(int number)
    {
        var exception = Record.Exception(() => (MPCSequentialNumber)number);

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
