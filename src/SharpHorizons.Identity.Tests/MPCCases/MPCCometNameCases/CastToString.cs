namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNames))]
    public void Valid_ExactMatch(MPCCometName mpcCometName)
    {
        var actual = (string)mpcCometName;

        Assert.Equal(mpcCometName.Value, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometNames))]
    public void Invalid_ArgumentException(MPCCometName mpcCometName)
    {
        var exception = Record.Exception(() => (string)mpcCometName);

        Assert.IsType<ArgumentException>(exception);
    }
}
