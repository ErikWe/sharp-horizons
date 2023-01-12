namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCNames))]
    public void Valid_NoException(MPCName mpcName)
    {
        var exception = Record.Exception(() => MPCName.Validate(mpcName));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCNames))]
    public void Invalid_ArgumentException(MPCName mpcName)
    {
        var exception = Record.Exception(() => MPCName.Validate(mpcName));

        Assert.IsType<ArgumentException>(exception);
    }
}
