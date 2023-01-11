namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Misc
{
    [Fact]
    public void ValueAccess_Invalid_InvalidOperationException()
    {
        var exception = Record.Exception(() => default(MPCCometDesignation).Value);

        Assert.IsType<InvalidOperationException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void ValueAccess_Valid_NoException(MPCCometDesignation mpcCometDesignation)
    {
        var exception = Record.Exception(() => mpcCometDesignation.Value);

        Assert.Null(exception);
    }

    [Fact]
    public void Validate_Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => MPCCometDesignation.Validate(default));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void Validate_Valid_NoException(MPCCometDesignation mpcCometDesignation)
    {
        var exception = Record.Exception(() => MPCCometDesignation.Validate(mpcCometDesignation));

        Assert.Null(exception);
    }
}
