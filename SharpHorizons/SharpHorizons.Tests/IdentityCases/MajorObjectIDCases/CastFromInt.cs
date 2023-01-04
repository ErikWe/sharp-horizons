namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using Xunit;

public class CastFromInt
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDInts))]
    public void Valid_ExactMatch(int id)
    {
        var actual = (MajorObjectID)id;

        Assert.Equal(id, actual.Value);
    }
}
