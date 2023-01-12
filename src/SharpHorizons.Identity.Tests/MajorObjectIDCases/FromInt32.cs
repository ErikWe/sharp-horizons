namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using Xunit;

public class FromInt32
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDInt32s))]
    public void Valid_ExactMatch(int id)
    {
        var actual = MajorObjectID.FromInt32(id);

        Assert.Equal(id, actual.Value);
    }
}
