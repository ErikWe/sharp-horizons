namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class FromString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignationStrings))]
    public void Valid_ExactMatch(string designation)
    {
        var actual = MPCCometDesignation.FromString(designation);

        Assert.Equal(designation, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignationStrings))]
    public void Invalid_ArgumentException(string designation)
    {
        var exception = Record.Exception(() => MPCCometDesignation.FromString(designation));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => MPCCometDesignation.FromString(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }
}
