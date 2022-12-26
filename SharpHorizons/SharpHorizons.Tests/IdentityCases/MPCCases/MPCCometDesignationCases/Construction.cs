namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignationStrings))]
    public void Valid_ExactMatch(string designation)
    {
        MPCCometDesignation actual = new(designation);

        Assert.Equal(designation, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignationStrings))]
    public void Invalid_ArgumentException(string designation)
    {
        var exception = Record.Exception(() => new MPCCometDesignation(designation));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCCometDesignation(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignationStrings))]
    public void Initialization_Valid_ExactMatch(string designation)
    {
        MPCCometDesignation actual = new() { Value = designation };

        Assert.Equal(designation, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignationStrings))]
    public void Initialization_Invalid_ArgumentException(string designation)
    {
        var exception = Record.Exception(() => new MPCCometDesignation() { Value = designation });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Initialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCCometDesignation() { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignationStrings))]
    public void Reinitialization_Valid_ExactMatch(string designation)
    {
        var actual = new MPCCometDesignation("1P") with { Value = designation };

        Assert.Equal(designation, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignationStrings))]
    public void Reinitialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MPCCometDesignation("1P") with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCCometDesignation("1P") with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }
}
