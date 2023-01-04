namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDInts))]
    public void Valid_ExactMatch(int id)
    {
        MajorObjectID actual = new() { Value = id };

        Assert.Equal(id, actual.Value);
    }
}
