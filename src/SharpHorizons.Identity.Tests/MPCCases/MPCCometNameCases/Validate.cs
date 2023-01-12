namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNames))]
    public void Valid_NoException(MPCCometName mpcCometName)
    {
        var exception = Record.Exception(() => MPCCometName.Validate(mpcCometName));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometNames))]
    public void Invalid_ArgumentException(MPCCometName mpcCometName)
    {
        var exception = Record.Exception(() => MPCCometName.Validate(mpcCometName));

        Assert.IsType<ArgumentException>(exception);
    }
}
