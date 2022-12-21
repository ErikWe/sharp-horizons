namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using System.Collections.Generic;

using Xunit;

public class Construction
{
    [Theory]
    [MemberData(nameof(MajorObjectIDs))]
    public void ExactMatch(int id)
    {
        MajorObjectID majorObjectID = new(id);

        Assert.Equal(id, majorObjectID.Value);
    }

    [Theory]
    [MemberData(nameof(MajorObjectIDs))]
    public void Initialization_ExactMatch(int id)
    {
        MajorObjectID majorObjectID = new() { Value = id };

        Assert.Equal(id, majorObjectID.Value);
    }

    [Theory]
    [MemberData(nameof(MajorObjectIDs))]
    public void CastFromInt_ExactMatch(int id)
    {
        var majorObjectID = (MajorObjectID)id;

        Assert.Equal(id, majorObjectID.Value);
    }

    public static IEnumerable<object[]> MajorObjectIDs() => new object[][]
    {
        new object[] { int.MaxValue },
        new object[] { int.MinValue },
        new object[] { 0 },
        new object[] { 1 },
        new object[] { -1 }
    };
}
