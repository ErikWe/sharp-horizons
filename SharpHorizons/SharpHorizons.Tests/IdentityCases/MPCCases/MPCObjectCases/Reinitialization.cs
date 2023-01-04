namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCObjectCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidNumberNameDesignationCombinations))]
    public void Valid_ExactMatch(MPCSequentialNumber number, MPCName name, MPCProvisionalDesignation designation)
    {
        var actual = InitialMPCObject with { SequentialNumber = number, Name = name, ProvisionalDesignation = designation };

        Assert.Equal(number, actual.SequentialNumber);
        Assert.Equal(name, actual.Name);
        Assert.Equal(designation, actual.ProvisionalDesignation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidNumberNameDesignationCombinations))]
    public void Invalid_ArgumentException(MPCSequentialNumber number, MPCName name, MPCProvisionalDesignation designation)
    {
        var exception = Record.Exception(() => InitialMPCObject with { SequentialNumber = number, Name = name, ProvisionalDesignation = designation });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void NullDesignationAndName_ArgumentException()
    {
        var initial = InitialMPCObject with { ProvisionalDesignation = null };

        var exception = Record.Exception(() => initial with { Name = null });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void NullNameAndDesignation_ArgumentException()
    {
        var initial = InitialMPCObject with { Name = null };

        var exception = Record.Exception(() => initial with { ProvisionalDesignation = null });

        Assert.IsType<ArgumentException>(exception);
    }

    private static MPCObject InitialMPCObject => MPCObject.Named(new MPCSequentialNumber(1), new MPCName("Ceres"), new MPCProvisionalDesignation("A801 AA"));
}
