namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(MPCCometDesignation designation, MPCCometName name)
    {
        MPCComet actual = new(designation, name);

        Assert.Equal(designation, actual.Designation);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Invalid_ArgumentException(MPCCometDesignation designation, MPCCometName name)
    {
        var exception = Record.Exception(() => new MPCComet(designation, name));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void NullName_ExactMatch(MPCCometDesignation designation)
    {
        MPCComet actual = new(designation, null);

        Assert.Equal(designation, actual.Designation);
        Assert.Null(actual.Name);
    }
}
