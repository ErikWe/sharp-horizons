namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCPrevisionalDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Misc
{
    [Fact]
    public void ValueAccess_Invalid_InvalidOperationException()
    {
        var exception = Record.Exception(() => default(MPCProvisionalDesignation).Value);

        Assert.IsType<InvalidOperationException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignations))]
    public void ValueAccess_Valid_NoException(MPCProvisionalDesignation mpcProvisionalDesignation)
    {
        var exception = Record.Exception(() => mpcProvisionalDesignation.Value);

        Assert.Null(exception);
    }

    [Fact]
    public void Validate_Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => MPCProvisionalDesignation.Validate(default));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignations))]
    public void Validate_Valid_NoException(MPCProvisionalDesignation mpcProvisionalDesignation)
    {
        var exception = Record.Exception(() => MPCProvisionalDesignation.Validate(mpcProvisionalDesignation));

        Assert.Null(exception);
    }
}
