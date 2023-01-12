namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using System.Globalization;

using Xunit;

public class ToStringInvariant_String
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void General_MatchInt32ToStringWithInvariantCulture(MajorObjectID majorObjectID)
    {
        var format = "G";

        var expected = majorObjectID.Value.ToString(format, CultureInfo.InvariantCulture);

        var actual = majorObjectID.ToStringInvariant(format);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Currency_MatchInt32ToStringWithInvariantCulture(MajorObjectID majorObjectID)
    {
        var format = "C";

        var expected = majorObjectID.Value.ToString(format, CultureInfo.InvariantCulture);

        var actual = majorObjectID.ToStringInvariant(format);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Null_MatchInt32ToStringWithInvariantCulture(MajorObjectID majorObjectID)
    {
        string? format = null;

        var expected = majorObjectID.Value.ToString(format, CultureInfo.InvariantCulture);

        var actual = majorObjectID.ToStringInvariant(format);

        Assert.Equal(expected, actual);
    }
}
