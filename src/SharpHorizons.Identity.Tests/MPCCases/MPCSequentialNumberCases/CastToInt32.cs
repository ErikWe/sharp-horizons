namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using Xunit;

public class CastToInt32
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMPCSequentialNumbers))]
    public void Valid_ExactMatch(MPCSequentialNumber mpcSequentialNumber)
    {
        var actual = (int)mpcSequentialNumber;

        Assert.Equal(mpcSequentialNumber.Value, actual);
    }
}
