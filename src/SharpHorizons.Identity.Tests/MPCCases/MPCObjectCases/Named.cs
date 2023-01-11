namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCObjectCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Named
{
    [Theory]
    [ClassData(typeof(Datasets.ValidNumberNameDesignationCombinations))]
    public void Valid_ExactMatch(MPCSequentialNumber number, MPCName name, MPCProvisionalDesignation designation)
    {
        var actual = MPCObject.Named(number, name, designation);

        Assert.Equal(number, actual.SequentialNumber);
        Assert.Equal(name, actual.Name);
        Assert.Equal(designation, actual.ProvisionalDesignation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidNumberNameDesignationCombinations))]
    public void Invalid_ArgumentException(MPCSequentialNumber number, MPCName name, MPCProvisionalDesignation designation)
    {
        var exception = Record.Exception(() => MPCObject.Named(number, name, designation));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidNumberNameCombinations))]
    public void WithoutDesignation_Valid_ExactMatch(MPCSequentialNumber number, MPCName name)
    {
        var actual = MPCObject.Named(number, name);

        Assert.Equal(number, actual.SequentialNumber);
        Assert.Equal(name, actual.Name);
        Assert.Null(actual.ProvisionalDesignation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidNumberNameCombinations))]
    public void WithoutDesignation_Invalid_ArgumentException(MPCSequentialNumber number, MPCName name)
    {
        var exception = Record.Exception(() => MPCObject.Named(number, name));

        Assert.IsType<ArgumentException>(exception);
    }
}
