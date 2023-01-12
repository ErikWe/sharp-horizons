namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using System;
using System.Globalization;

using Xunit;

public class ToString_StringIFormatProvider
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void General_MatchInt32ToString(MajorObjectID majorObjectID)
    {
        var format = "G";
        var culture = CultureInfo.CurrentCulture;

        var expected = majorObjectID.Value.ToString(format, culture);

        var actual = majorObjectID.ToString(format, culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Currency_MatchInt32ToString(MajorObjectID majorObjectID)
    {
        var format = "C";
        var culture = CultureInfo.CurrentCulture;

        var expected = majorObjectID.Value.ToString(format, culture);

        var actual = majorObjectID.ToString(format, culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void NullString_MatchInt32ToString(MajorObjectID majorObjectID)
    {
        string? format = null;
        var culture = CultureInfo.CurrentCulture;

        var expected = majorObjectID.Value.ToString(format, culture);

        var actual = majorObjectID.ToString(format, culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void NullIFormatProvider_MatchInt32ToString(MajorObjectID majorObjectID)
    {
        var format = "G";
        IFormatProvider? culture = null;

        var expected = majorObjectID.Value.ToString(format, culture);

        var actual = majorObjectID.ToString(format, culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void NullStringAndIFormatProvider_MatchInt32ToString(MajorObjectID majorObjectID)
    {
        string? format = null;
        IFormatProvider? culture = null;

        var expected = majorObjectID.Value.ToString(format, culture);

        var actual = majorObjectID.ToString(format, culture);

        Assert.Equal(expected, actual);
    }
}
