namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCPrevisionalDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignationStrings))]
    public void Valid_ExactMatch(string designation)
    {
        MPCProvisionalDesignation actual = new(designation);

        Assert.Equal(designation, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignationStrings))]
    public void Invalid_ArgumentException(string designation)
    {
        var exception = Record.Exception(() => new MPCProvisionalDesignation(designation));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCProvisionalDesignation(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

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

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignationStrings))]
    public void Reinitialization_Valid_ExactMatch(string designation)
    {
        var actual = new MPCProvisionalDesignation("A807 FA") with { Value = designation };

        Assert.Equal(designation, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignationStrings))]
    public void Reinitialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MPCProvisionalDesignation("A807 FA") with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCProvisionalDesignation("A807 FA") with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }
}
