namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class CastFromString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        var actual = (MPCCometName)name;

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => (MPCCometName)name);

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (MPCCometName)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
