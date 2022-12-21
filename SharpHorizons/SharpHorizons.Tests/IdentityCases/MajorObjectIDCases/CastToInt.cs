namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using System.Collections.Generic;

using Xunit;

public class CastToInt
{
    [Theory]
    [MemberData(nameof(MajorObjectIDs))]
    public void ExactMatch(int id)
    {
        MajorObjectID majorObjectID = new(id);

        Assert.Equal(id, (int)majorObjectID);
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
