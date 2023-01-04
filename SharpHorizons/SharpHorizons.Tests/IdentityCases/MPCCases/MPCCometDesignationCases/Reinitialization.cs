namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignationStrings))]
    public void Reinitialization_Valid_ExactMatch(string designation)
    {
        var actual = InitialMPCCometDesignation with { Value = designation };

        Assert.Equal(designation, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignationStrings))]
    public void Reinitialization_Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => InitialMPCCometDesignation with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => InitialMPCCometDesignation with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    private static MPCCometDesignation InitialMPCCometDesignation => new("1P");
}
