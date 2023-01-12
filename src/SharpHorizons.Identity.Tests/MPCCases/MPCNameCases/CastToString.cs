namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCNames))]
    public void Valid_ExactMatch(MPCName mpcName)
    {
        var actual = (string)mpcName;

        Assert.Equal(mpcName.Value, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMPCNames))]
    public void Invalid_ArgumentException(MPCName mpcName)
    {
        var exception = Record.Exception(() => (string)mpcName);

        Assert.IsType<ArgumentException>(exception);
    }
}
