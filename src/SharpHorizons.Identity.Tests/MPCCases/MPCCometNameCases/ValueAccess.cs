namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNames))]
    public void Valid_NoException(MPCCometName mpcCometName)
    {
        var exception = Record.Exception(() => mpcCometName.Value);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometNames))]
    public void Invalid_InvalidOperationException(MPCCometName mpcCometName)
    {
        var exception = Record.Exception(() => mpcCometName.Value);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
