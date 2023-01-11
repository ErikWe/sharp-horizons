namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Misc
{
    [Fact]
    public void ValueAccess_Invalid_InvalidOperationException()
    {
        var exception = Record.Exception(() => default(MPCCometName).Value);

        Assert.IsType<InvalidOperationException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNames))]
    public void ValueAccess_Valid_NoException(MPCCometName mpcCometName)
    {
        var exception = Record.Exception(() => mpcCometName.Value);

        Assert.Null(exception);
    }

    [Fact]
    public void Validate_Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => MPCCometName.Validate(default));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNames))]
    public void Validate_Valid_NoException(MPCCometName mpcCometName)
    {
        var exception = Record.Exception(() => MPCCometName.Validate(mpcCometName));

        Assert.Null(exception);
    }
}
