namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using System.Globalization;

using Xunit;

public class ToStringInvariant
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Valid_MatchInt32ToStringWithInvariantCulture(MajorObjectID majorObjectID)
    {
        var expected = majorObjectID.Value.ToString(CultureInfo.InvariantCulture);

        var actual = majorObjectID.ToStringInvariant();

        Assert.Equal(expected, actual);
    }
}
