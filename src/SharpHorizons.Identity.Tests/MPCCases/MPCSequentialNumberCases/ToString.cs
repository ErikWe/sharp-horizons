namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString().")]
    public void Valid_MatchInt32ToStringWithCurrentCulture(MPCSequentialNumber mpcSequentialNumber)
    {
        var expected = mpcSequentialNumber.Value.ToString(CultureInfo.CurrentCulture);

        var actual = mpcSequentialNumber.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumbers))]
    public void Invalid_InvalidOperationException(MPCSequentialNumber mpcSequentialNumber)
    {
        var exception = Record.Exception(mpcSequentialNumber.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
