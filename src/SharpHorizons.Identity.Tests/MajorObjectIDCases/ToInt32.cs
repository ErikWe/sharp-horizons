namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using Xunit;

public class ToInt32
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Valid_ExactMatchValue(MajorObjectID majorObjectID)
    {
        var expected = majorObjectID.Value;

        var actual = majorObjectID.ToInt32();

        Assert.Equal(expected, actual);
    }
}
