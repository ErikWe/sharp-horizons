namespace SharpHorizons.Tests.IdentityCases.MajorObjectCases;

using System;

using Xunit;

public class Constructor_MajorObjectIDMajorObjectName
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
}
