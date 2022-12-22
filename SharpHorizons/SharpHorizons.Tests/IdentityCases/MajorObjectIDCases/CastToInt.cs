namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using Xunit;

public class CastToInt
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void ExactMatch(MajorObjectID majorObjectID)
    {
        var actual = (int)majorObjectID;

        Assert.Equal(majorObjectID.Value, actual);
    }
}
