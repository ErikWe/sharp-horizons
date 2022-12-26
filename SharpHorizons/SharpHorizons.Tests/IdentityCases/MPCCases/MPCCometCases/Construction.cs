namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(MPCCometDesignation designation, MPCCometName name)
    {
        MPCComet actual = new(designation, name);

        Assert.Equal(designation, actual.Designation);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Invalid_ArgumentException(MPCCometDesignation designation, MPCCometName name)
    {
        var exception = Record.Exception(() => new MPCComet(designation, name));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void NullName_ValidDesignation_ExactMatch(MPCCometDesignation designation)
    {
        MPCComet actual = new(designation, null);

        Assert.Equal(designation, actual.Designation);
        Assert.Null(actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignations))]
    public void NullName_InvalidDesignation_ArgumentException(MPCCometDesignation designation)
    {
        var exception = Record.Exception(() => new MPCComet(designation, null));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void JustDesignation_Valid_ExactMatch(MPCCometDesignation designation)
    {
        MPCComet actual = new(designation);

        Assert.Equal(designation, actual.Designation);
        Assert.Null(actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignations))]
    public void JustDesignation_Invalid_ArgumentException(MPCCometDesignation designation)
    {
        var exception = Record.Exception(() => new MPCComet(designation));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Initialization_Valid_ExactMatch(MPCCometDesignation designation, MPCCometName name)
    {
        MPCComet actual = new() { Designation = designation, Name = name };

        Assert.Equal(designation, actual.Designation);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Initialization_Invalid_ArgumentException(MPCCometDesignation designation, MPCCometName name)
    {
        var exception = Record.Exception(() => new MPCComet() { Designation = designation, Name = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void Initialization_NullName_ValidDesignation_ExactMtach(MPCCometDesignation designation)
    {
        MPCComet actual = new() { Designation = designation, Name = null };

        Assert.Equal(designation, actual.Designation);
        Assert.Null(actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignations))]
    public void Initialization_NullName_InvalidDesignation_ArgumentException(MPCCometDesignation designation)
    {
        var exception = Record.Exception(() => new MPCComet() { Designation = designation, Name = null });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void Initialization_JustDesignation_Valid_ExactMtach(MPCCometDesignation designation)
    {
        MPCComet actual = new() { Designation = designation };

        Assert.Equal(designation, actual.Designation);
        Assert.Null(actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignations))]
    public void Initialization_JustDesignation_Invalid_ArgumentException(MPCCometDesignation designation)
    {
        var exception = Record.Exception(() => new MPCComet() { Designation = designation });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Reinitialization_Valid_ExactMatch(MPCCometDesignation designation, MPCCometName name)
    {
        var actual = new MPCComet(new MPCCometDesignation("1P"), new MPCCometName("Halley")) with { Designation = designation, Name = name };

        Assert.Equal(designation, actual.Designation);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Reinitialization_Invalid_ArgumentException(MPCCometDesignation designation, MPCCometName name)
    {
        var exception = Record.Exception(() => new MPCComet(new MPCCometDesignation("1P"), new MPCCometName("Halley")) with { Designation = designation, Name = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void Reinitialization_NullName_ValidDesignation_ExactMtach(MPCCometDesignation designation)
    {
        var actual = new MPCComet(new MPCCometDesignation("1P"), new MPCCometName("Halley")) with { Designation = designation, Name = null };

        Assert.Equal(designation, actual.Designation);
        Assert.Null(actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignations))]
    public void Reinitialization_NullName_InvalidDesignation_ArgumentException(MPCCometDesignation designation)
    {
        var exception = Record.Exception(() => new MPCComet(new MPCCometDesignation("1P"), new MPCCometName("Halley")) with { Designation = designation, Name = null });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void Reinitialization_JustDesignation_Valid_ExactMtach(MPCCometDesignation designation)
    {
        var actual = new MPCComet(new MPCCometDesignation("1P")) with { Designation = designation };

        Assert.Equal(designation, actual.Designation);
        Assert.Null(actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignations))]
    public void Reinitialization_JustDesignation_Invalid_ArgumentException(MPCCometDesignation designation)
    {
        var exception = Record.Exception(() => new MPCComet(new MPCCometDesignation("1P")) with { Designation = designation });

        Assert.IsType<ArgumentException>(exception);
    }
}
