namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNames))]
    public void Valid_ExactMatchValue(MPCCometName mpcCometName)
    {
        var expected = mpcCometName.Value;

        var actual = mpcCometName.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometNames))]
    public void Invalid_InvalidOperationException(MPCCometName mpcCometName)
    {
        var exception = Record.Exception(mpcCometName.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
