namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCNames))]
    public void Valid_ExactMatchValue(MPCName mpcName)
    {
        var expected = mpcName.Value;

        var actual = mpcName.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCNames))]
    public void Invalid_InvalidOperationException(MPCName mpcName)
    {
        var exception = Record.Exception(mpcName.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
