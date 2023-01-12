namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using Xunit;

public class CastFromInt32
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDInt32s))]
    public void Valid_ExactMatch(int id)
    {
        var actual = (MajorObjectID)id;

        Assert.Equal(id, actual.Value);
    }
}
