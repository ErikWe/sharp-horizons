namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCPrevisionalDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignationStrings))]
    public void Reinitialization_Valid_ExactMatch(string designation)
    {
        var actual = InitialMPCProvisionalDesignation with { Value = designation };

        Assert.Equal(designation, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignationStrings))]
    public void Reinitialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => InitialMPCProvisionalDesignation with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => InitialMPCProvisionalDesignation with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    private static MPCProvisionalDesignation InitialMPCProvisionalDesignation => new("A801 AA");
}
