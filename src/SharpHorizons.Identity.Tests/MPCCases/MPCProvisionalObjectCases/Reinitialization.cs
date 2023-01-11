namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCProvisionalObjectCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignations))]
    public void Valid_ExactMatch(MPCProvisionalDesignation designation)
    {
        var actual = InitialMPCProvisionalObject with { Designation = designation };

        Assert.Equal(designation, actual.Designation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignation))]
    public void Invalid_ArgumentException(MPCProvisionalDesignation designation)
    {
        var exception = Record.Exception(() => InitialMPCProvisionalObject with { Designation = designation });

        Assert.IsType<ArgumentException>(exception);
    }

    private static MPCProvisionalObject InitialMPCProvisionalObject => new(new MPCProvisionalDesignation("A801 AA"));
}
