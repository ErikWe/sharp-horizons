namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCPrevisionalDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignations))]
    public void Valid_ExactMatch(MPCProvisionalDesignation mpcProvisionalDesignation)
    {
        var actual = (string)mpcProvisionalDesignation;

        Assert.Equal(mpcProvisionalDesignation.Value, actual);
    }

    [Fact]
    public void Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => (string)default(MPCProvisionalDesignation));

        Assert.IsType<ArgumentException>(exception);
    }
}
