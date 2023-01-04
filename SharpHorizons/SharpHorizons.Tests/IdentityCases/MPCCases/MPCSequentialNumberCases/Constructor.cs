namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Constructor
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
}
