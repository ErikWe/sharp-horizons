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

    [Fact]
    public void Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => (string)default(MPCCometDesignation));

        Assert.IsType<ArgumentException>(exception);
    }
}
