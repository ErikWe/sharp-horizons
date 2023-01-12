namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class ToInt32
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void Valid_ExactMatchValue(MPCSequentialNumber mpcSequentialNumber)
    {
        var expected = mpcSequentialNumber.Value;

        var actual = mpcSequentialNumber.ToInt32();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumbers))]
    public void Invalid_InvalidOperationException(MPCSequentialNumber mpcSequentialNumber)
    {
        var exception = Record.Exception(() => mpcSequentialNumber.ToInt32());

        Assert.IsType<InvalidOperationException>(exception);
    }
}
