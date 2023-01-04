namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class CastFromString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCNameStrings))]
    public void Valid_ExactMatch(string name)
    {
        var actual = (MPCName)name;

        Assert.Equal(name, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCNameStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => (MPCName)name);

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (MPCName)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
