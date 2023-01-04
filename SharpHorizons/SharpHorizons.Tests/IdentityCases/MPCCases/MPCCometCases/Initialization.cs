namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(MPCCometDesignation designation, MPCCometName name)
    {
        MPCComet actual = new() { Designation = designation, Name = name };

        Assert.Equal(designation, actual.Designation);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Invalid_ArgumentException(MPCCometDesignation designation, MPCCometName name)
    {
        var exception = Record.Exception(() => new MPCComet() { Designation = designation, Name = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void NullName_ExactMatch(MPCCometDesignation designation)
    {
        MPCComet actual = new() { Designation = designation, Name = null };

        Assert.Equal(designation, actual.Designation);
        Assert.Null(actual.Name);
    }
}
