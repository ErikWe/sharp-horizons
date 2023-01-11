namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometNameCases;

using SharpHorizons.MPC;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCCometNames))]
    public void Valid_ExactMatch(MPCCometName mpcCometName)
    {
        var actual = (string)mpcCometName;

        Assert.Equal(mpcCometName.Value, actual);
    }

    [Fact]
    public void Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => (string)default(MPCCometName));

        Assert.IsType<ArgumentException>(exception);
    }
}
