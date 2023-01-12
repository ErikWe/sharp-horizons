namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using System;
using System.Globalization;

using Xunit;

public class ToString_IFormatProvider
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Valid_MatchInt32ToString(MajorObjectID majorObjectID)
    {
        var culture = CultureInfo.CurrentCulture;

        var expected = majorObjectID.Value.ToString(culture);

        var actual = majorObjectID.ToString(culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Null_MatchInt32ToString(MajorObjectID majorObjectID)
    {
        IFormatProvider? culture = null;

        var expected = majorObjectID.Value.ToString(culture);

        var actual = majorObjectID.ToString(culture);

        Assert.Equal(expected, actual);
    }
}
