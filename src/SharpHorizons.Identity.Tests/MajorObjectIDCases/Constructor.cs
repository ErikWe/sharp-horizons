namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDInt32s))]
    public void Valid_ExactMatch(int id)
    {
        MajorObjectID actual = new(id);

        Assert.Equal(id, actual.Value);
    }
}
