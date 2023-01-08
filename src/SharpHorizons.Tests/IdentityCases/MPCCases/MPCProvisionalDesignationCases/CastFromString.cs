namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCPrevisionalDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class CastFromString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignationStrings))]
    public void Valid_ExactMatch(string designation)
    {
        var actual = (MPCProvisionalDesignation)designation;

        Assert.Equal(designation, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignationStrings))]
    public void Invalid_ArgumentException(string designation)
    {
        var exception = Record.Exception(() => (MPCProvisionalDesignation)designation);

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (MPCProvisionalDesignation)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
