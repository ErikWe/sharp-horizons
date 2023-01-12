namespace SharpHorizons.Tests.IdentityCases.MajorObjectCases;

using Xunit;

public class Constructor_MajorObjectID
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Valid_ExactMatchIDAndNullName(MajorObjectID id)
    {
        MajorObject actual = new(id);

        Assert.Equal(id, actual.ID);
        Assert.Null(actual.Name);
    }
}
