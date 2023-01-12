namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;
using System.Globalization;

using Xunit;

public class ToStringInvariant
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void Valid_MatchInt32ToStringWithInvariantCulture(MPCSequentialNumber mpcSequentialNumber)
    {
        var expected = mpcSequentialNumber.Value.ToString(CultureInfo.InvariantCulture);

        var actual = mpcSequentialNumber.ToStringInvariant();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumbers))]
    public void Invalid_InvalidOperationException(MPCSequentialNumber mpcSequentialNumber)
    {
        var exception = Record.Exception(mpcSequentialNumber.ToStringInvariant);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
