namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using Xunit;

public class CastToInt32
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Valid_ExactMatchValue(MajorObjectID majorObjectID)
    {
        var expected = majorObjectID.Value;

        var actual = (int)majorObjectID;

        Assert.Equal(expected, actual);
    }
}
