namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        var actual = InitialMPCCometName with { Value = name };

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => InitialMPCCometName with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => InitialMPCCometName with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    private static MPCCometName InitialMPCCometName => new("Halley");
}
