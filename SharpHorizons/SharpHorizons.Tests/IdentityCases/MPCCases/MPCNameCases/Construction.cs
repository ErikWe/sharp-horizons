namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        MPCName actual = new(name);

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MPCName(name));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCName(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCNameStrings))]
    public void Initialization_Valid_ExactMatch(string name)
    {
        MPCName actual = new() { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCNameStrings))]
    public void Initialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MPCName() { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Initialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCName() { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCNameStrings))]
    public void Reinitialization_Valid_ExactMatch(string name)
    {
        var actual = new MPCName("Vesta") with { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCNameStrings))]
    public void Reinitialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => new MPCName("Vesta") with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new MPCName("Vesta") with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }
}
