namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCProvisionalObjectCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignations))]
    public void Valid_ExactMatch(MPCProvisionalDesignation designation)
    {
        MPCProvisionalObject actual = new() { Designation = designation };

        Assert.Equal(designation, actual.Designation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignation))]
    public void Invalid_ArgumentException(MPCProvisionalDesignation designation)
    {
        var exception = Record.Exception(() => new MPCProvisionalObject() { Designation = designation });

        Assert.IsType<ArgumentException>(exception);
    }
}
