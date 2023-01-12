namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void Valid_ExactMatchValue(MPCCometDesignation mpcCometDesignation)
    {
        var expected = mpcCometDesignation.Value;

        var actual = mpcCometDesignation.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignations))]
    public void Invalid_InvalidOperationException(MPCCometDesignation mpcCometDesignation)
    {
        var exception = Record.Exception(mpcCometDesignation.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
