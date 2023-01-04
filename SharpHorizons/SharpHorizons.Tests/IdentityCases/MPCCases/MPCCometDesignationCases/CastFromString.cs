namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class CastFromString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignationStrings))]
    public void Valid_ExactMatch(string designation)
    {
        var actual = (MPCCometDesignation)designation;

        Assert.Equal(designation, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignationStrings))]
    public void Invalid_ArgumentException(string designation)
    {
        var exception = Record.Exception(() => (MPCCometDesignation)designation);

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (MPCCometDesignation)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
