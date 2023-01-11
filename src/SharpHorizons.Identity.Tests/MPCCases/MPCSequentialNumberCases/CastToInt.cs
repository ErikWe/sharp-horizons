namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using Xunit;

public class CastToInt
{
    [Theory]
    [ClassData(typeof(Datasets.MPCSequentialNumbers))]
    public void ExactMatch(MPCSequentialNumber mpcSequentialNumber)
    {
        var actual = (int)mpcSequentialNumber;

        Assert.Equal(mpcSequentialNumber.Value, actual);
    }
}
