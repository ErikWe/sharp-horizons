namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometDesignationCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometDesignations))]
    public void Valid_ExactMatch(MPCCometDesignation mpcCometDesignation)
    {
        var actual = (string)mpcCometDesignation;

        Assert.Equal(mpcCometDesignation.Value, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCCometDesignations))]
    public void Invalid_ArgumentException(MPCCometDesignation mpcCometDesignation)
    {
        var exception = Record.Exception(() => (string)mpcCometDesignation);

        Assert.IsType<ArgumentException>(exception);
    }
}
