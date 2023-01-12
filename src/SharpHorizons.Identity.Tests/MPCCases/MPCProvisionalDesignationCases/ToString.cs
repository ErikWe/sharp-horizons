namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCPrevisionalDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCProvisionalDesignations))]
    public void Valid_ExactMatchValue(MPCProvisionalDesignation mpcProvisionalDesignation)
    {
        var expected = mpcProvisionalDesignation.Value;

        var actual = mpcProvisionalDesignation.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCProvisionalDesignations))]
    public void Invalid_InvalidOperationException(MPCProvisionalDesignation mpcProvisionalDesignation)
    {
        var exception = Record.Exception(mpcProvisionalDesignation.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
