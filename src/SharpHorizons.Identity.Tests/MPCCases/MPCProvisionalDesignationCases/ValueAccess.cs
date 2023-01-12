namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCPrevisionalDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignations))]
    public void Valid_NoException(MPCProvisionalDesignation mpcProvisionalDesignation)
    {
        var exception = Record.Exception(() => mpcProvisionalDesignation.Value);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignations))]
    public void Invalid_InvalidOperationException(MPCProvisionalDesignation mpcProvisionalDesignation)
    {
        var exception = Record.Exception(() => mpcProvisionalDesignation.Value);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
