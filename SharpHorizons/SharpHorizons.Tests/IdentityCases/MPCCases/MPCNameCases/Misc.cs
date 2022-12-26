namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class Misc
{
    [Fact]
    public void ValueAccess_Invalid_InvalidOperationException()
    {
        var exception = Record.Exception(() => default(MPCName).Value);

        Assert.IsType<InvalidOperationException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCNames))]
    public void ValueAccess_Valid_NoException(MPCName mpcName)
    {
        var exception = Record.Exception(() => mpcName.Value);

        Assert.Null(exception);
    }

    [Fact]
    public void Validate_Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => MPCName.Validate(default));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidMPCNames))]
    public void Validate_Valid_NoException(MPCName mpcName)
    {
        var exception = Record.Exception(() => MPCName.Validate(mpcName));

        Assert.Null(exception);
    }
}
