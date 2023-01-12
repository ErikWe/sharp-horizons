namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCPrevisionalDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignations))]
    public void Valid_NoException(MPCProvisionalDesignation mpcProvisionalDesignation)
    {
        var exception = Record.Exception(() => MPCProvisionalDesignation.Validate(mpcProvisionalDesignation));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignations))]
    public void Invalid_ArgumentException(MPCProvisionalDesignation mpcProvisionalDesignation)
    {
        var exception = Record.Exception(() => MPCProvisionalDesignation.Validate(mpcProvisionalDesignation));

        Assert.IsType<ArgumentException>(exception);
    }
}
