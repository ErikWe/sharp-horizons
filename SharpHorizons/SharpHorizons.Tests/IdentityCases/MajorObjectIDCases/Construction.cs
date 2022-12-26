namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using Xunit;

public class Construction
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDInts))]
    public void ExactMatch(int id)
    {
        MajorObjectID actual = new(id);

        Assert.Equal(id, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDInts))]
    public void Initialization_ExactMatch(int id)
    {
        MajorObjectID actual = new() { Value = id };

        Assert.Equal(id, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDInts))]
    public void Reinitialization_ExactMatch(int id)
    {
        var actual = new MajorObjectID(0) with { Value = id };

        Assert.Equal(id, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDInts))]
    public void CastFromInt_ExactMatch(int id)
    {
        var actual = (MajorObjectID)id;

        Assert.Equal(id, actual.Value);
    }
}
