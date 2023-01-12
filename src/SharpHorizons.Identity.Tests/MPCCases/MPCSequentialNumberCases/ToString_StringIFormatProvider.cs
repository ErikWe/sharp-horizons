namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;
using System.Globalization;

using Xunit;

public class ToString_StringIFormatProvider
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void General_MatchInt32ToString(MPCSequentialNumber mpcSequentialNumber)
    {
        var format = "G";
        var culture = CultureInfo.CurrentCulture;

        var expected = mpcSequentialNumber.Value.ToString(format, culture);

        var actual = mpcSequentialNumber.ToString(format, culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void Currency_MatchInt32ToString(MPCSequentialNumber mpcSequentialNumber)
    {
        var format = "C";
        var culture = CultureInfo.CurrentCulture;

        var expected = mpcSequentialNumber.Value.ToString(format, culture);

        var actual = mpcSequentialNumber.ToString(format, culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void NullString_MatchInt32ToString(MPCSequentialNumber mpcSequentialNumber)
    {
        string? format = null;
        var culture = CultureInfo.CurrentCulture;

        var expected = mpcSequentialNumber.Value.ToString(format, culture);

        var actual = mpcSequentialNumber.ToString(format, culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void NullIFormatProvider_MatchInt32ToString(MPCSequentialNumber mpcSequentialNumber)
    {
        var format = "G";
        IFormatProvider? culture = null;

        var expected = mpcSequentialNumber.Value.ToString(format, culture);

        var actual = mpcSequentialNumber.ToString(format, culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void NullStringAndIFormatProvider_MatchInt32ToString(MPCSequentialNumber mpcSequentialNumber)
    {
        string? format = null;
        IFormatProvider? culture = null;

        var expected = mpcSequentialNumber.Value.ToString(format, culture);

        var actual = mpcSequentialNumber.ToString(format, culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumbers))]
    public void Invalid_InvalidOperationException(MPCSequentialNumber mpcSequentialNumber)
    {
        var format = "G";
        var culture = CultureInfo.CurrentCulture;

        var exception = Record.Exception(() => mpcSequentialNumber.ToString(format, culture));

        Assert.IsType<InvalidOperationException>(exception);
    }
}
