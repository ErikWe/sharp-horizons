namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        var actual = InitialMPCName with { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => InitialMPCName with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => InitialMPCName with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    private static MPCName InitialMPCName => new("Ceres");
}
