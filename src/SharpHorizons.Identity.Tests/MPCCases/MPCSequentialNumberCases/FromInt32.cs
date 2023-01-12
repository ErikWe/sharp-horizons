namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class FromInt32
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumberInt32s))]
    public void Valid_ExactMatch(int number)
    {
        var actual = MPCSequentialNumber.FromInt32(number);

        Assert.Equal(number, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumberInt32s))]
    public void Invalid_ArgumentOutOfRangeException(int number)
    {
        var exception = Record.Exception(() => MPCSequentialNumber.FromInt32(number));

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}
