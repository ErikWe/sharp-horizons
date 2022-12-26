namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCObjectCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Construction
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
    [ClassData(typeof(Datasets.ValidNumberDesignationCombinations))]
    public void Unnamed_ValidNumberAndDesignation_ExactMatch(MPCSequentialNumber number, MPCProvisionalDesignation designation)
    {
        var actual = MPCObject.Unnamed(number, designation);

        Assert.Equal(number, actual.SequentialNumber);
        Assert.Null(actual.Name);
        Assert.Equal(designation, actual.ProvisionalDesignation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidNumberDesignationCombinations))]
    public void Unnamed_InvalidNumberOrDesignation_ArgumentException(MPCSequentialNumber number, MPCProvisionalDesignation designation)
    {
        var exception = Record.Exception(() => MPCObject.Unnamed(number, designation));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidNumberNameCombinations))]
    public void WithoutDesignation_ValidNumberAndName_ExactMatch(MPCSequentialNumber number, MPCName name)
    {
        var actual = MPCObject.Named(number, name);

        Assert.Equal(number, actual.SequentialNumber);
        Assert.Equal(name, actual.Name);
        Assert.Null(actual.ProvisionalDesignation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidNumberNameCombinations))]
    public void WithoutDesignation_InvalidNumberOrName_ArgumentException(MPCSequentialNumber number, MPCName name)
    {
        var exception = Record.Exception(() => MPCObject.Named(number, name));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidNumberNameDesignationCombinations))]
    public void Reinitialization_Valid_ExactMatch(MPCSequentialNumber number, MPCName name, MPCProvisionalDesignation designation)
    {
        var actual = MPCObject.Named(new MPCSequentialNumber(1), new MPCName("Vesta"), new MPCProvisionalDesignation("A807 FA")) with { SequentialNumber = number, Name = name, ProvisionalDesignation = designation };

        Assert.Equal(number, actual.SequentialNumber);
        Assert.Equal(name, actual.Name);
        Assert.Equal(designation, actual.ProvisionalDesignation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidNumberNameDesignationCombinations))]
    public void Reinitialization_Invalid_ArgumentException(MPCSequentialNumber number, MPCName name, MPCProvisionalDesignation designation)
    {
        var exception = Record.Exception(() => MPCObject.Named(new MPCSequentialNumber(1), new MPCName("Vesta"), new MPCProvisionalDesignation("A807 FA")) with { SequentialNumber = number, Name = name, ProvisionalDesignation = designation });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidNumberDesignationCombinations))]
    public void Reinitialization_Unnamed_ValidNumberAndDesignation_ExactMatch(MPCSequentialNumber number, MPCProvisionalDesignation designation)
    {
        var actual = MPCObject.Unnamed(new MPCSequentialNumber(1), new MPCProvisionalDesignation("A807 FA")) with { SequentialNumber = number, ProvisionalDesignation = designation };

        Assert.Equal(number, actual.SequentialNumber);
        Assert.Null(actual.Name);
        Assert.Equal(designation, actual.ProvisionalDesignation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidNumberDesignationCombinations))]
    public void Reinitialization_Unnamed_InvalidNumberOrDesignation_ArgumentException(MPCSequentialNumber number, MPCProvisionalDesignation designation)
    {
        var exception = Record.Exception(() => MPCObject.Unnamed(new MPCSequentialNumber(1), new MPCProvisionalDesignation("A807 FA")) with { SequentialNumber = number, ProvisionalDesignation = designation });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_Unnamed_NullDesignation_ArgumentException()
    {
        var exception = Record.Exception(() => MPCObject.Unnamed(new MPCSequentialNumber(1), new MPCProvisionalDesignation("A807 FA")) with { ProvisionalDesignation = null });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidNumberNameCombinations))]
    public void Reinitialization_WithoutDesignation_ValidNumberAndName_ExactMatch(MPCSequentialNumber number, MPCName name)
    {
        var actual = MPCObject.Named(new MPCSequentialNumber(1), new MPCName("Vesta")) with { SequentialNumber = number, Name = name };

        Assert.Equal(number, actual.SequentialNumber);
        Assert.Equal(name, actual.Name);
        Assert.Null(actual.ProvisionalDesignation);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidNumberNameCombinations))]
    public void Reinitialization_WithoutDesignation_InvalidNumberOrDesignation_ArgumentException(MPCSequentialNumber number, MPCName name)
    {
        var exception = Record.Exception(() => MPCObject.Named(new MPCSequentialNumber(1), new MPCName("A807 FA")) with { SequentialNumber = number, Name = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Reinitialization_WithoutDesignation_NullName_ArgumentException()
    {
        var exception = Record.Exception(() => MPCObject.Named(new MPCSequentialNumber(1), new MPCName("Vesta")) with { Name = null });

        Assert.IsType<ArgumentException>(exception);
    }
}
