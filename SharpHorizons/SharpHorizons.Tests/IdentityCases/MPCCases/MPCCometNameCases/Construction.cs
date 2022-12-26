namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        MPCCometName actual = new(name);

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MPCCometName(name));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCCometName(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNameStrings))]
    public void Initialization_Valid_ExactMatch(string name)
    {
        MPCCometName actual = new() { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometNameStrings))]
    public void Initialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MPCCometName() { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Initialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCCometName() { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNameStrings))]
    public void Reinitialization_Valid_ExactMatch(string name)
    {
        var actual = new MPCCometName("Halley") with { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometNameStrings))]
    public void Reinitialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MPCCometName("Halley") with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCCometName("Halley") with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }
}
