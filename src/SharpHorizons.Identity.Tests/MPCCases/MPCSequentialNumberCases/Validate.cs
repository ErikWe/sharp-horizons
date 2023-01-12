namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void Valid_NoException(MPCSequentialNumber mpcSequentialNumber)
    {
        var exception = Record.Exception(() => MPCSequentialNumber.Validate(mpcSequentialNumber));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCSequentialNumbers))]
    public void Invalid_InvalidOperationException(MPCSequentialNumber mpcSequentialNumber)
    {
        var exception = Record.Exception(() => MPCSequentialNumber.Validate(mpcSequentialNumber));

        Assert.IsType<ArgumentException>(exception);
    }
}
