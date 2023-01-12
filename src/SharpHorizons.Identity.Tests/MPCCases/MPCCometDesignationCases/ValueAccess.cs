namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void Valid_NoException(MPCCometDesignation mpcCometDesignation)
    {
        var exception = Record.Exception(() => mpcCometDesignation.Value);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignations))]
    public void Invalid_InvalidOperationException(MPCCometDesignation mpcCometDesignation)
    {
        var exception = Record.Exception(() => mpcCometDesignation.Value);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
