namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCProvisionalObjectCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignations))]
    public void Valid_ExactMatch(MPCProvisionalDesignation designation)
    {
        MPCProvisionalObject actual = new(designation);

        Assert.Equal(designation, actual.Designation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignation))]
    public void Invalid_ArgumentException(MPCProvisionalDesignation designation)
    {
        var exception = Record.Exception(() => new MPCProvisionalObject(designation));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignations))]
    public void Initialization_Valid_ExactMatch(MPCProvisionalDesignation designation)
    {
        MPCProvisionalObject actual = new() { Designation = designation };

        Assert.Equal(designation, actual.Designation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignation))]
    public void Initialization_Invalid_ArgumentException(MPCProvisionalDesignation designation)
    {
        var exception = Record.Exception(() => new MPCProvisionalObject() { Designation = designation });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignations))]
    public void Reinitialization_Valid_ExactMatch(MPCProvisionalDesignation designation)
    {
        var actual = new MPCProvisionalObject(new MPCProvisionalDesignation("A807 FA")) with { Designation = designation };

        Assert.Equal(designation, actual.Designation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignation))]
    public void Reinitialization_Invalid_ArgumentException(MPCProvisionalDesignation designation)
    {
        var exception = Record.Exception(() => new MPCProvisionalObject(new MPCProvisionalDesignation("A807 FA")) with { Designation = designation });

        Assert.IsType<ArgumentException>(exception);
    }
}
