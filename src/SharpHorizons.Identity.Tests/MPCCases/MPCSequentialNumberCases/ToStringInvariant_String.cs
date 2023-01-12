namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;
using System.Globalization;

using Xunit;

public class ToStringInvariant_String
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void General_MatchInt32ToStringWithInvariantCulture(MPCSequentialNumber mpcSequentialNumber)
    {
        var format = "G";

        var expected = mpcSequentialNumber.Value.ToString(format, CultureInfo.InvariantCulture);

        var actual = mpcSequentialNumber.ToStringInvariant(format);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void Currency_MatchInt32ToStringWithInvariantCulture(MPCSequentialNumber mpcSequentialNumber)
    {
        var format = "C";

        var expected = mpcSequentialNumber.Value.ToString(format, CultureInfo.InvariantCulture);

        var actual = mpcSequentialNumber.ToStringInvariant(format);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void Null_MatchInt32ToStringWithInvariantCulture(MPCSequentialNumber mpcSequentialNumber)
    {
        string? format = null;

        var expected = mpcSequentialNumber.Value.ToString(format, CultureInfo.InvariantCulture);

        var actual = mpcSequentialNumber.ToStringInvariant(format);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumbers))]
    public void Invalid_InvalidOperationException(MPCSequentialNumber mpcSequentialNumber)
    {
        var format = "G";

        var exception = Record.Exception(() => mpcSequentialNumber.ToStringInvariant(format));

        Assert.IsType<InvalidOperationException>(exception);
    }
}
