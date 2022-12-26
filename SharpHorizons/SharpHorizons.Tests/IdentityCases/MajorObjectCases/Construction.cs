namespace SharpHorizons.Tests.IdentityCases.MajorObjectCases;

using System;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(MajorObjectID id, MajorObjectName name)
    {
        MajorObject actual = new(id, name);

        Assert.Equal(id, actual.ID);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Invalid_ArgumentException(MajorObjectID id, MajorObjectName name)
    {
        var exception = Record.Exception(() => new MajorObject(id, name));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void NullName_ExactMatch(MajorObjectID id)
    {
        MajorObject actual = new(id, null);

        Assert.Equal(id, actual.ID);
        Assert.Null(actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void JustID_ExactMatch(MajorObjectID id)
    {
        MajorObject actual = new(id);

        Assert.Equal(id, actual.ID);
        Assert.Null(actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Initialization_Valid_ExactMatch(MajorObjectID id, MajorObjectName name)
    {
        MajorObject actual = new() { ID = id, Name = name };

        Assert.Equal(id, actual.ID);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Initialization_Invalid_ArgumentException(MajorObjectID id, MajorObjectName name)
    {
        var exception = Record.Exception(() => new MajorObject() { ID = id, Name = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Initialization_NullName_ExactMtach(MajorObjectID id)
    {
        MajorObject actual = new() { ID = id, Name = null };

        Assert.Equal(id, actual.ID);
        Assert.Null(actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Initialization_JustID_ExactMtach(MajorObjectID id)
    {
        MajorObject actual = new() { ID = id };

        Assert.Equal(id, actual.ID);
        Assert.Null(actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Reinitialization_Valid_ExactMatch(MajorObjectID id, MajorObjectName name)
    {
        var actual = new MajorObject(new MajorObjectID(0), new MajorObjectName("Earth")) with { ID = id, Name = name };

        Assert.Equal(id, actual.ID);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Reinitialization_Invalid_ArgumentException(MajorObjectID id, MajorObjectName name)
    {
        var exception = Record.Exception(() => new MajorObject(new MajorObjectID(0), new MajorObjectName("Earth")) with { ID = id, Name = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Reinitialization_NullName_ExactMtach(MajorObjectID id)
    {
        var actual = new MajorObject(new MajorObjectID(0), new MajorObjectName("Earth")) with { ID = id, Name = null };

        Assert.Equal(id, actual.ID);
        Assert.Null(actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Reinitialization_JustID_ExactMtach(MajorObjectID id)
    {
        var actual = new MajorObject(new MajorObjectID(0)) with { ID = id };

        Assert.Equal(id, actual.ID);
        Assert.Null(actual.Name);
    }
}
