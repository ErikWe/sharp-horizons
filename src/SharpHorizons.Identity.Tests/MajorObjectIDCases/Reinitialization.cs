namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDInts))]
    public void Valid_ExactMatch(int id)
    {
        var actual = InitialMajorObjectID with { Value = id };

        Assert.Equal(id, actual.Value);
    }

    private static MajorObjectID InitialMajorObjectID => new(399);
}
