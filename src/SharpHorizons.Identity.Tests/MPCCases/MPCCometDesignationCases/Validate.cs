namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void Valid_NoException(MPCCometDesignation mpcCometDesignation)
    {
        var exception = Record.Exception(() => MPCCometDesignation.Validate(mpcCometDesignation));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignations))]
    public void Invalid_ArgumentException(MPCCometDesignation mpcCometDesignation)
    {
        var exception = Record.Exception(() => MPCCometDesignation.Validate(mpcCometDesignation));

        Assert.IsType<ArgumentException>(exception);
    }
}
