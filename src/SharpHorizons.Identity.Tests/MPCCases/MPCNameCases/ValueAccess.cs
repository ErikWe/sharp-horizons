namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCNames))]
    public void Valid_NoException(MPCName mpcName)
    {
        var exception = Record.Exception(() => mpcName.Value);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCNames))]
    public void Invalid_InvalidOperationException(MPCName mpcName)
    {
        var exception = Record.Exception(() => mpcName.Value);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
