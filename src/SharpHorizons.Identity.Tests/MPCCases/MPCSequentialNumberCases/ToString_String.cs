namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString_String
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString(string).")]
    public void General_MatchInt32ToStringWithCurrentCulture(MPCSequentialNumber mpcSequentialNumber)
    {
        var format = "G";

        var expected = mpcSequentialNumber.Value.ToString(format, CultureInfo.CurrentCulture);

        var actual = mpcSequentialNumber.ToString(format);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString(string).")]
    public void Currency_MatchInt32ToStringWithCurrentCulture(MPCSequentialNumber mpcSequentialNumber)
    {
        var format = "C";

        var expected = mpcSequentialNumber.Value.ToString(format, CultureInfo.CurrentCulture);

        var actual = mpcSequentialNumber.ToString(format);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString(string).")]
    public void Null_MatchInt32ToStringWithCurrentCulture(MPCSequentialNumber mpcSequentialNumber)
    {
        string? format = null;

        var expected = mpcSequentialNumber.Value.ToString(format, CultureInfo.CurrentCulture);

        var actual = mpcSequentialNumber.ToString(format);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumbers))]
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString(string).")]
    public void Invalid_InvalidOperationException(MPCSequentialNumber mpcSequentialNumber)
    {
        var format = "G";

        var exception = Record.Exception(() => mpcSequentialNumber.ToString(format));

        Assert.IsType<InvalidOperationException>(exception);
    }
}
