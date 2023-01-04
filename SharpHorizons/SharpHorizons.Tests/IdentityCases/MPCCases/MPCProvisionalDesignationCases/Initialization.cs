namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCPrevisionalDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignationStrings))]
    public void Initialization_Valid_ExactMatch(string designation)
    {
        MPCProvisionalDesignation actual = new() { Value = designation };

        Assert.Equal(designation, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignationStrings))]
    public void Initialization_Invalid_ArgumentException(string designation)
    {
        var exception = Record.Exception(() => new MPCProvisionalDesignation() { Value = designation });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Initialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCProvisionalDesignation() { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }
}
