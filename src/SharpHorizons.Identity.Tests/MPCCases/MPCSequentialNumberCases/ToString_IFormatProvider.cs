namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;
using System.Globalization;

using Xunit;

public class ToString_IFormatProvider
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void Valid_MatchInt32ToString(MPCSequentialNumber mpcSequentialNumber)
    {
        var culture = CultureInfo.CurrentCulture;

        var expected = mpcSequentialNumber.Value.ToString(culture);

        var actual = mpcSequentialNumber.ToString(culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void Null_MatchInt32ToString(MPCSequentialNumber mpcSequentialNumber)
    {
        IFormatProvider? culture = null;

        var expected = mpcSequentialNumber.Value.ToString(culture);

        var actual = mpcSequentialNumber.ToString(culture);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumbers))]
    public void Invalid_InvalidOperationException(MPCSequentialNumber mpcSequentialNumber)
    {
        var culture = CultureInfo.CurrentCulture;

        var exception = Record.Exception(() => mpcSequentialNumber.ToString(culture));

        Assert.IsType<InvalidOperationException>(exception);
    }
}
