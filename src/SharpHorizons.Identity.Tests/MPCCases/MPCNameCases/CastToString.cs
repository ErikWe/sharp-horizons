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

    [Fact]
    public void Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => (string)default(MPCName));

        Assert.IsType<ArgumentException>(exception);
    }
}
