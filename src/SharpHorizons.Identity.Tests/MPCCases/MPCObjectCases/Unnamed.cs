namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCObjectCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Unnamed
{
    [Theory]
    [ClassData(typeof(Datasets.ValidNumberDesignationCombinations))]
    public void Valid_ExactMatch(MPCSequentialNumber number, MPCProvisionalDesignation designation)
    {
        var actual = MPCObject.Unnamed(number, designation);

        Assert.Equal(number, actual.SequentialNumber);
        Assert.Null(actual.Name);
        Assert.Equal(designation, actual.ProvisionalDesignation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidNumberDesignationCombinations))]
    public void Invalid_ArgumentException(MPCSequentialNumber number, MPCProvisionalDesignation designation)
    {
        var exception = Record.Exception(() => MPCObject.Unnamed(number, designation));

        Assert.IsType<ArgumentException>(exception);
    }
}
