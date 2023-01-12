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

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignations))]
    public void Invalid_ArgumentException(MPCProvisionalDesignation mpcProvisionalDesignation)
    {
        var exception = Record.Exception(() => (string)mpcProvisionalDesignation);

        Assert.IsType<ArgumentException>(exception);
    }
}
