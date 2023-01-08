namespace SharpHorizons.Tests.IdentityCases.MajorObjectCases;

using System;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(MajorObjectID id, MajorObjectName name)
    {
        MajorObject actual = new() { ID = id, Name = name };

        Assert.Equal(id, actual.ID);
        Assert.Equal(name, actual.Name);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidCombinations))]
    public void Invalid_ArgumentException(MajorObjectID id, MajorObjectName name)
    {
        var exception = Record.Exception(() => new MajorObject() { ID = id, Name = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void NullName_ExactMatch(MajorObjectID id)
    {
        MajorObject actual = new() { ID = id, Name = null };

        Assert.Equal(id, actual.ID);
        Assert.Null(actual.Name);
    }
}
